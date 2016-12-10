using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using NetOffice.OutlookApi.Enums;
using TKD.Emailer.Dtos;
using TKD.Emailer.Models;
using Outlook = NetOffice.OutlookApi;

namespace TKD.Emailer.Services
{
    internal class EmailService
    {
        public ResultDTO SendEmail(IEnumerable<EmailRecipientDTO> recipientDtos, string subject, string body)
        {
            var result = new ResultDTO
            {
                Errors = new List<ErrorDTO>()
            };

            var ol = GetOutlookIfRunning();

            try
            {
                var outlookApplication = ol ?? new Outlook.Application();
                var mailItem = BuildMail(recipientDtos, subject, body, outlookApplication);
                mailItem.Send();

                //Quits outlook if it wasn't running before we ran this program
                if (ol == null)
                {
                    outlookApplication.Quit();
                    outlookApplication.Dispose();
                }
            }
            catch (ArgumentException ex)
            {
                var error = new ErrorDTO
                {
                    FullException = ex,
                    Message = "Configuration error "
                };
                result.Errors.Add(error);
            }

            return result;
        }

        private static Outlook.Application GetOutlookIfRunning()
        {
            var runningOutlookProcesses = Process.GetProcessesByName("OUTLOOK");
            Outlook.Application ol = null;
            if (runningOutlookProcesses.Length > 0)
            {
                ol = (Outlook.Application) Marshal.GetActiveObject("Outlook.Application");
            }
            return ol;
        }

        private static Outlook.MailItem BuildMail(IEnumerable<EmailRecipientDTO> recipientDtos, string subject, string body, Outlook.Application outlookApplication)
        {
            var mailItem = outlookApplication.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;

            var recipientEmails = string.Join(";", recipientDtos.Select(recipient => recipient.Email));

            mailItem.Recipients.Add(recipientEmails);
            mailItem.Subject = subject;
            mailItem.Body = body;
            return mailItem;
        }
    }
}
