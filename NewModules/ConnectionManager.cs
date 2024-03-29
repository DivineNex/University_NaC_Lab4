﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewModules
{
    internal class ConnectionManager
    {
        MainForm mainForm;
        public string serverIP;
        public int serverPort;
        public Socket serverSocket;
        private IPEndPoint ipPoint;
        public bool connected = false;
        private Thread serverSocketThread;
        private MessageParser messageParser;
        public bool manualDisconnection = false;

        public string loggedStatus = "none";
        public string registrationStatus = "none";

        public ConnectionManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            messageParser = new MessageParser(mainForm);
        }

        public void ConnectToServer()
        {
            if (!connected)
            {
                try
                {
                    mainForm.AddLog("Подключение...");
                    ipPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
                    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    // подключаемся к удаленному хосту
                    serverSocket.Connect(ipPoint);
                    mainForm.AddLog($"Соединение с сервером {serverSocket.RemoteEndPoint} установлено");
                    serverSocketThread = new Thread(() => SocketThread());
                    serverSocketThread.Start();
                    SendInitMessage();

                    connected = true;
                    mainForm.SetConnectionStatus(true);
                    manualDisconnection = false;
                }
                catch (Exception ex)
                {
                    mainForm.AddLog(ex.Message);
                }
            }
            else
            {
                mainForm.AddLog("Подключение уже установлено");
            }
        }

        public void DisconnectFromServer()
        {
                mainForm.AddLog($"Соединение с сервером {serverSocket.RemoteEndPoint} разорвано");
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Close();

                connected = false;
                manualDisconnection = true;
                mainForm.SetConnectionStatus(false);
        }

        private void SendInitMessage()
        {
            string message = "&init//desktop";
            byte[] data = Encoding.Unicode.GetBytes(message);
            serverSocket.Send(data);
        }

        public void SendAuthMessage(string login, string password, out string result)
        {
            try
            {
                string message = $"&auth//desktop//{login}//{password}";
                byte[] data = Encoding.Unicode.GetBytes(message);
                serverSocket.Send(data);

                while (true)
                {
                    if (loggedStatus == "logged")
                    {
                        result = "Авторизация выполнена успешно";
                        break;
                    }
                    else if (loggedStatus == "fail")
                    {
                        result = "Ошибка авторизации";
                        loggedStatus = "none";
                        break;
                    }
                }

            }
            catch
            {
                result = "Сервер недоступен";
            }
        }

        public void SendRegistrationMessage(string login, string password, out string result)
        {
            try
            {
                string message = $"&registration//desktop//{login}//{password}";
                byte[] data = Encoding.Unicode.GetBytes(message);
                serverSocket.Send(data);

                while (true)
                {
                    if (registrationStatus == "registered")
                    {
                        result = "Регистрация прошла успешно";
                        break;
                    }
                    else if (registrationStatus == "fail")
                    {
                        result = "Логин занят!";
                        registrationStatus = "none";
                        break;
                    }
                }

            }
            catch
            {
                result = "Сервер недоступен";
            }
        }

        private void SocketThread()
        {
            while (true)
            {
                try
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    do
                    {
                        bytes = serverSocket.Receive(data);

                        if (bytes <= 0)
                        {
                            throw new SocketException();
                        }

                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (serverSocket.Available > 0);

                    string recievedMessage = builder.ToString();

                    //Для разделения мультимессенджинга
                    string[] splittedRecievedMessage = recievedMessage.Split('&');
                    for (int i = 0; i < splittedRecievedMessage.Length; i++)
                    {
                        if (splittedRecievedMessage[i] != "")
                        {
                            messageParser.ParseMessage(splittedRecievedMessage[i]);
                        }
                    }
                }
                catch
                {
                    try
                    {
                        if (!manualDisconnection)
                            mainForm.AddLog($"Соединение с сервером {serverSocket.RemoteEndPoint} потеряно");
                        mainForm.SetConnectionStatus(false);
                    }
                    catch { }

                    connected = false;
                    serverSocket.Close();
                    break;
                }
            }
        }
    }
}
