REM \emsdk\emsdk_env.bat
REM em++ ../cpp/BibleBookInquiry.cpp ../cpp/BibleBook.cpp -s WASM=1 -o BibleBookInquiry.js || exit 1
REM em++ ../cpp/BibleBook.cpp ../cpp/BibleBookInquiry.cpp ../../IfEntiretyBeTheSame/cpp/IfEntiretyBeTheSame.cpp -s STANDALONE_WASM -s WASM=1 -s EXPORT_ALL=1 -s ERROR_ON_UNDEFINED_SYMBOLS=0 -o BibleBookInquiry.html -s "EXTRA_EXPORTED_RUNTIME_METHODS=['ccall']"
em++ ../cpp/BibleBook.cpp ../cpp/BibleBookInquiry.cpp -s STANDALONE_WASM -s WASM=1 -s EXPORT_ALL=1 -s ERROR_ON_UNDEFINED_SYMBOLS=0 -o BibleBookInquiry.html -s "EXTRA_EXPORTED_RUNTIME_METHODS=['ccall']"
REM wasm-dis BibleBookInquiry.wasm -o BibleBookInquiry.wast
move BibleBookInquiry.js ../web/gen/
move BibleBookInquiry.wasm ../web/gen/

REM cl ../cpp/BibleBookInquiry.cpp ../cpp/BibleBook.cpp