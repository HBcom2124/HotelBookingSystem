﻿using HotelBookingSystem.BAL.Absractes;

namespace HotelBookingSystem.BAL.Concrets
{
    public class MailingServices : IMailing
    {
        //public MailSettings _mailSettings { get; }
        //public ILogger<MailingServices> _logger { get; }

        //public MailService(IOptions<MailSettings> mailSettings, ILogger<MailingServices> logger)
        //{
        //    _mailSettings = mailSettings.Value;
        //    _logger = logger;
        //}
        //public async Task SendEmailAsync(MailRequest mailRequest)
        //{
        //    try
        //    {
        //        // create message
        //        var email = new MimeMessage();
        //        email.Sender = MailboxAddress.Parse(mailRequest.From ?? _mailSettings.EmailFrom);
        //        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        //        email.Subject = mailRequest.Subject;
        //        var builder = new BodyBuilder();
        //        builder.HtmlBody = mailRequest.Body;
        //        email.Body = builder.ToMessageBody();
        //        using var smtp = new SmtpClient();
        //        smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
        //        smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
        //        await smtp.SendAsync(email);
        //        smtp.Disconnect(true);

        //    }
        //    catch (System.Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        throw new ApiException(ex.Message);
        //    }
        //}
    }
}