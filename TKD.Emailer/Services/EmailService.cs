﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            try
            {
                var outlookApplication = new Outlook.Application();
                var mailItem = BuildMail(recipientDtos, subject, body, outlookApplication);
                mailItem.Send();
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
