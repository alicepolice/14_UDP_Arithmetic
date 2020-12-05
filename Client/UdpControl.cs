using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class UdpControl : MonoBehaviour
{

    public Button SendButton;
    public InputField ContextField;
    public Text FeedBack;

    private byte[] data = new byte[1024];
    private byte[] send = new byte[1024];

    private IPEndPoint e = new IPEndPoint(IPAddress.Parse("192.168.43.160"), 7788);  //这里定义向固定主机发送信息
    private UdpClient udpClient = new UdpClient();
    private IPEndPoint server = new IPEndPoint(IPAddress.Any, 0); //这里定义接收信息的范围

    private Thread a;
    private bool isget = false;
    private string message = string.Empty;
    void Start()
    {
        SendButton.onClick.AddListener(Send);
    }

    private void Update()
    {
        if (!string.IsNullOrEmpty(message) && isget == true)
        {
            FeedBack.text = message;
            message = "";
            isget = false;
        }
    }

    void Send()
    {
        send = Encoding.UTF8.GetBytes(ContextField.text);
        udpClient.Send(send, send.Length, e);

        a = new Thread(Receive);
        a.Start();

       // FeedBack.text = "数据发送成功！";
        ContextField.text = "";

       // Thread.Sleep(1000);
       //发送数据
    }

    public void Receive()
    {
        while (true)
        {
            data = udpClient.Receive(ref server);
            int length = data.Length;
            if (length > 0)
            {
                IPEndPoint serverDetails = server as IPEndPoint;
                string message = Encoding.UTF8.GetString(data, 0, length);
                message = "表达式：" + message.Split('^')[0] + "\n答案：" + message.Split('^')[1];
                print("服务器：" + serverDetails.Address + ":" + serverDetails.Port + "发来数据");
                print(message);
                FB(message);
                break;
            }

        }
    }

    public void FB(string i)
    {
        message = "接收服务器数据\n" + i;
        isget = true;
    }
}

