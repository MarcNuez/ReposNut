using DataAccess.MailServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MailServices
{
    class SystemSupportMail:MasterMailServer
    {
        public SystemSupportMail()
        {
            senderMail = "marcnuez92@gmail.com";
            password = "";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
                
        }
    }
}
