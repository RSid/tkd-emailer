﻿using System;
using System.Collections.Generic;
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

            foreach (var emailRecipientDTO in recipientDtos)
            {
                var recipientToBCC = mailItem.Recipients.Add(emailRecipientDTO.Email);
                recipientToBCC.Type = (int)OlMailRecipientType.olBCC;
            }
            mailItem.Recipients.ResolveAll();
            mailItem.Subject = subject;
            mailItem.Body = body;
            return mailItem;
        }
    }
}
