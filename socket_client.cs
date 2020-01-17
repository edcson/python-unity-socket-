using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using UnityEngine.UI;
using System.Text;
public class socket_client : MonoBehaviour
{
    private Socket tcpSocket;
    public Button button1;
    private Socket clientSocket;
    private Thread t;
    private byte[] data = new byte[1024];//这个是一个数据容器
    public string message;
    int a = 0;
    //1、创建socket
    Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    public void Start()
    {
        //2、发起连接的请求
        IPAddress ipaddress = IPAddress.Parse("127.0.0.1");//可以把一个字符串的ip地址转化成一个IPaddress的对象
        EndPoint point = new IPEndPoint(ipaddress, 7777);
        tcpClient.Connect(point);//通过ip：端口号 定位一个要连接的服务器端  
        button1.onClick.AddListener(OnBtnConnect);//开始
    }
    void Update()
    {
        if (a==1)
        {
            string message2 = "我连进来啦！";//用户输入 给客户端的信息
            tcpClient.Send(Encoding.UTF8.GetBytes(message2));//把字符串转化成字节数组，然后发送到服务器端
            int length = tcpClient.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
            Debug.Log(message);
            a = 0;
        }
    }
    public void OnBtnConnect()
    {
        a = 1;
    }
}