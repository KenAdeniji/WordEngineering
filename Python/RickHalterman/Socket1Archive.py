"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-20T14:54	https://www.py4e.com/code3/socket1.py
"""

if __name__ == '__main__':
	import socket

	mysock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	mysock.connect(('data.pr4e.org', 80))
	cmd = 'GET http://data.pr4e.org/romeo.txt HTTP/1.0\r\n\r\n'.encode()
	mysock.send(cmd)

	while True:
		data = mysock.recv(512)
		if len(data) < 1:
			break
		print(data.decode(),end='')

	mysock.close()
	