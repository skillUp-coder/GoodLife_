using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLossSystem.BL.DTO
{
    public class EmailSettings
    {
        public string MailToAddress = "enterMail";
        public string MailFromAddress = "enterMail";
        public bool UseSsl = true;
        public string Username = "enterMail";
        public string Password = "enterPassword";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"enter path";
    }
}
