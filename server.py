from socket import AF_INET, SOCK_DGRAM, SOCK_STREAM
import socket
host = '127.0.0.1'
port = 7777
server = socket.socket(AF_INET, SOCK_STREAM)       # 创建一个基于网络通信的TCP协议的socket对象
server.bind((host, port))
server.listen(5)    # 5表示最大的同时连接数

conn,addr = server.accept()  # conn表示链接；addr表示地址；返回的结果是一个元组
msg = conn.recv(1024)   # 接受信息，1024表示接收1024个字节的信息
print("客户端发来的消息是:%s" %msg.decode('utf-8'))
conn.send("1".encode("utf-8"))  # 发送的消息
# 断开链接
conn.close()
server.close()