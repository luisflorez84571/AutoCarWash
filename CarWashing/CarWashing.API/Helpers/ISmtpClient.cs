﻿using MimeKit;

namespace CarWashing.API.Helpers
{
    public interface ISmtpClient
    {
        void Connect(string host, int port, bool useSsl);

        void Authenticate(string username, string password);

        void Send(MimeMessage message);

        void Disconnect(bool quit);
    }
}