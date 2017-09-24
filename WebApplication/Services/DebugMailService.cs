using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public class DebugMailService : IMailService    
    {
        public void SendMail(string to, string message)
        {
            Debug.WriteLine($"Sending mail to: {to} with message:{message}");
        }
    }
}
