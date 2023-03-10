package mssql

import (
	"bytes"
	"errors"
	"testing"
)

type closableBuffer struct {
	*bytes.Buffer
}

func (closableBuffer) Close() error {
	return nil
}

type failBuffer struct {
}

func (failBuffer) Read([]byte) (int, error) {
	return 0, errors.New("read failed")
}

func (failBuffer) Write([]byte) (int, error) {
	return 0, errors.New("write failed")
}

func (failBuffer) Close() error {
	return nil
}

func makeBuf(bufSize uint16, testData []byte) *tdsBuffer {
	buffer := closableBuffer{bytes.NewBuffer(testData)}
	return newTdsBuffer(bufSize, &buffer)
}

func TestStreamShorterThanHeader(t *testing.T) {
	//buffer := closableBuffer{*bytes.NewBuffer([]byte{0xFF, 0xFF})}
	//buffer := closableBuffer{*bytes.NewBuffer([]byte{0x6F, 0x96, 0x19, 0xFF, 0x8B, 0x86, 0xD0, 0x11, 0xB4, 0x2D, 0x00, 0xC0, 0x4F, 0xC9, 0x64, 0xFF})}
	//tdsBuffer := newTdsBuffer(100, &buffer)
	buffer := makeBuf(100, []byte{0xFF, 0xFF})
	_, err := buffer.BeginRead()
	if err == nil {
		t.Fatal("BeginRead was expected to return error but it didn't")
	} else {
		t.Log("BeginRead failed as expected with error:", err.Error())
	}
}

func TestInvalidLengthInHeaderTooLong(t *testing.T) {
	buffer := makeBuf(8, []byte{0xFF, 0xFF, 0x0, 0x9, 0xff, 0xff, 0xff, 0xff})
	_, err := buffer.BeginRead()
	if err == nil {
		t.Fatal("BeginRead was expected to return error but it didn't")
	} else {
		if err.Error() != "Invalid packet size, it is longer than buffer size" {
			t.Fatal("BeginRead failed with incorrect error", err)
		} else {
			t.Log("BeginRead failed as expected with error:", err.Error())
		}
	}
}

func TestInvalidLengthInHeaderTooShort(t *testing.T) {
	buffer := makeBuf(100, []byte{0xFF, 0xFF, 0x0, 0x1, 0xff, 0xff, 0xff, 0xff})
	_, err := buffer.BeginRead()
	if err == nil {
		t.Fatal("BeginRead was expected to return error but it didn't")
	} else {
		t.Log("BeginRead failed as expected with error:", err.Error())
	}
}

func TestInvalidLengthInHeaderLongerThanIncomingBuffer(t *testing.T) {
	buffer := makeBuf(9, []byte{0xFF, 0xFF, 0x0, 0x9, 0xff, 0xff, 0xff, 0xff})
	_, err := buffer.BeginRead()
	if err == nil {
		t.Fatal("BeginRead was expected to return error but it didn't")
	} else {
		t.Log("BeginRead failed as expected with error:", err.Error())
	}
}

func TestBeginReadSucceeds(t *testing.T) {
	buffer := makeBuf(9, []byte{0x01 /*id*/, 0xFF /*status*/, 0x0, 0x9 /*size*/, 0xff, 0xff, 0xff, 0xff, 0x02 /*test byte*/})

	id, err := buffer.BeginRead()
	if err != nil {
		t.Fatal("BeginRead failed:", err.Error())
	}
	if id != 1 {
		t.Fatalf("Expected id to be 1 but it is %d", id)
	}

	b, err := buffer.ReadByte()
	if err != nil {
		t.Fatal("ReadByte failed:", err.Error())
	}
	if b != 2 {
		t.Fatalf("Expected read byte to be 2 but it is %d", b)
	}

	// should fail because no more bytes left
	_, err = buffer.ReadByte()
	if err == nil {
		t.Fatal("ReadByte was expected to return error but it didn't")
	} else {
		t.Log("ReadByte failed as expected with error:", err.Error())
	}

	testBuf := []byte{0, 1, 2}
	// should fail because no more bytes left
	_, err = buffer.Read(testBuf)
	if err == nil {
		t.Fatal("Read was expected to return error but it didn't")
	} else {
		t.Log("Read failed as expected with error:", err.Error())
	}
}

func TestReadByteFailsOnSecondPacket(t *testing.T) {
	buffer := makeBuf(9, []byte{
		0x01 /*id*/, 0x0 /*not final*/, 0x0, 0x9 /*size*/, 0xff, 0xff, 0xff, 0xff, 0x02, /*test byte*/
		0x01 /*next id, this packet is invalid, it is too short*/})

	_, err := buffer.BeginRead()
	if err != nil {
		t.Fatal("BeginRead failed:", err.Error())
	}

	_, err = buffer.ReadByte()
	if err != nil {
		t.Fatal("ReadByte failed:", err.Error())
	}

	_, err = buffer.ReadByte()
	if err == nil {
		t.Fatal("ReadByte was expected to return error but it didn't")
	} else {
		t.Log("ReadByte failed as expected with error:", err.Error())
	}

	t.Run("test byte() panic", func(t *testing.T) {
		defer func() {
			recover()
		}()
		buffer.byte()
		t.Fatal("byte() should panic, but it didn't")
	})

	t.Run("test ReadFull() panic", func(t *testing.T) {
		defer func() {
			recover()
		}()
		buf := make([]byte, 10)
		buffer.ReadFull(buf)
		t.Fatal("ReadFull() should panic, but it didn't")
	})
}

func TestReadFailsOnSecondPacket(t *testing.T) {
	buffer := makeBuf(9, []byte{
		0x01 /*id*/, 0x0 /*not final*/, 0x0, 0x9 /*size*/, 0xff, 0xff, 0xff, 0xff, 0x02, /*test byte*/
		0x01 /*next id, this packet is invalid, it is too short*/})

	_, err := buffer.BeginRead()
	if err != nil {
		t.Fatal("BeginRead failed:", err.Error())
	}

	testBuf := []byte{0}
	_, err = buffer.Read(testBuf)
	if err != nil {
		t.Fatal("Read failed:", err.Error())
	}
	if testBuf[0] != 2 {
		t.Fatal("Read returned invalid value")
	}

	_, err = buffer.Read(testBuf)
	if err == nil {
		t.Fatal("ReadByte was expected to return error but it didn't")
	} else {
		t.Log("ReadByte failed as expected with error:", err.Error())
	}
}

func TestWrite(t *testing.T) {
	memBuf := bytes.NewBuffer([]byte{})
	buf := newTdsBuffer(11, closableBuffer{memBuf})
	buf.BeginPacket(1, false)
	err := buf.WriteByte(2)
	if err != nil {
		t.Fatal("WriteByte failed:", err.Error())
	}
	wrote, err := buf.Write([]byte{3, 4})
	if err != nil {
		t.Fatal("Write failed:", err.Error())
	}
	if wrote != 2 {
		t.Fatalf("Write returned invalid value of written bytes %d", wrote)
	}

	err = buf.FinishPacket()
	if err != nil {
		t.Fatal("FinishPacket failed:", err.Error())
	}
	if bytes.Compare(memBuf.Bytes(), []byte{1, 1, 0, 11, 0, 0, 1, 0, 2, 3, 4}) != 0 {
		t.Fatalf("Written buffer has invalid content: %v", memBuf.Bytes())
	}

	buf.BeginPacket(2, false)
	wrote, err = buf.Write([]byte{3, 4, 5, 6})
	if err != nil {
		t.Fatal("Write failed:", err.Error())
	}
	if wrote != 4 {
		t.Fatalf("Write returned invalid value of written bytes %d", wrote)
	}
	err = buf.FinishPacket()
	if err != nil {
		t.Fatal("FinishPacket failed:", err.Error())
	}
	expectedBuf := []byte{
		1, 1, 0, 11, 0, 0, 1, 0, 2, 3, 4, // packet 1
		2, 0, 0, 11, 0, 0, 1, 0, 3, 4, 5, // packet 2
		2, 1, 0, 9, 0, 0, 2, 0, 6, // packet 3
	}
	if bytes.Compare(memBuf.Bytes(), expectedBuf) != 0 {
		t.Fatalf("Written buffer has invalid content:\n got: %v\nwant: %v", memBuf.Bytes(), expectedBuf)
	}
}

func TestWriteErrors(t *testing.T) {
	// write should fail if underlying transport fails
	buf := newTdsBuffer(uint16(headerSize)+1, failBuffer{})
	buf.BeginPacket(1, false)
	wrote, err := buf.Write([]byte{0, 0})
	// may change from error to panic in future
	if err == nil {
		t.Fatal("Write should fail but it didn't")
	}
	if wrote != 1 {
		t.Fatal("Should write 1 byte but it wrote ", wrote)
	}

	// writebyte should fail if underlying transport fails
	buf = newTdsBuffer(uint16(headerSize)+1, failBuffer{})
	buf.BeginPacket(1, false)
	// first write should not fail because if fits in the buffer
	err = buf.WriteByte(0)
	if err != nil {
		t.Fatal("First WriteByte should not fail because it should fit in the buffer, but it failed", err)
	}
	err = buf.WriteByte(0)
	// may change from error to panic in future
	if err == nil {
		t.Fatal("Second WriteByte should fail but it didn't")
	}
}

func TestWrite_BufferBounds(t *testing.T) {
	memBuf := bytes.NewBuffer([]byte{})
	buf := newTdsBuffer(11, closableBuffer{memBuf})

	buf.BeginPacket(1, false)
	// write bytes enough to complete a package
	_, err := buf.Write([]byte{1, 1, 1})
	if err != nil {
		t.Fatal("Write failed:", err.Error())
	}
	err = buf.WriteByte(1)
	if err != nil {
		t.Fatal("WriteByte failed:", err.Error())
	}
	_, err = buf.Write([]byte{1, 1, 1})
	if err != nil {
		t.Fatal("Write failed:", err.Error())
	}
	err = buf.FinishPacket()
	if err != nil {
		t.Fatal("FinishPacket failed:", err.Error())
	}
}

func TestReadUsVarCharOrPanic(t *testing.T) {
	memBuf := bytes.NewBuffer([]byte{3, 0, 0x31, 0, 0x32, 0, 0x33, 0})
	s := readUsVarCharOrPanic(memBuf)
	if s != "123" {
		t.Errorf("UsVarChar expected to return 123 but it returned %s", s)
	}

	// test invalid usvarchar
	defer func() {
		recover()
	}()
	memBuf = bytes.NewBuffer([]byte{})
	s = readUsVarCharOrPanic(memBuf)
	t.Fatal("UsVarChar() should panic, but it didn't")
}

func TestReadBVarCharOrPanic(t *testing.T) {
	memBuf := bytes.NewBuffer([]byte{3, 0x31, 0, 0x32, 0, 0x33, 0})
	s := readBVarCharOrPanic(memBuf)
	if s != "123" {
		t.Errorf("readBVarCharOrPanic expected to return 123 but it returned %s", s)
	}

	// test invalid varchar
	defer func() {
		recover()
	}()
	memBuf = bytes.NewBuffer([]byte{})
	s = readBVarCharOrPanic(memBuf)
	t.Fatal("readBVarCharOrPanic() should panic on empty buffer, but it didn't")
}
