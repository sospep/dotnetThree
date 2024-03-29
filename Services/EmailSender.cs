using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using System;


namespace WebPWrecover.Services
{
    public class EmailSender : IEmailSender
    {
        /*  original working code 
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        */
        public EmailSender(IOptions<EmailSettings> optionsAccessor)
        {
            //_token = emailSettings.Options.token;
            Options = optionsAccessor.Value; 
        }
        public EmailSettings Options {get;} 
        public async Task SendEmailAsync( string userName, string subject, string emailBody)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(Options.SMTPdisplayname, Options.SMTPusername));
                mimeMessage.To.Add(new MailboxAddress(userName, userName));
                mimeMessage.Subject = subject ; 
                mimeMessage.Body = new TextPart("html")
                {
                    Text =  emailBody // AUTOmagical - this is the confirm your registration with verification code html message
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    
                    /* 
                    if (_env.IsDevelopment())
                    {
                        // The third parameter is useSSL (true if the client should make an SSL-wrapped
                        // connection to the server; otherwise, false).
                        await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, true);
                    }
                    else
                    {
                        await client.ConnectAsync(_emailSettings.MailServer);
                    }
                    */

                    // TEST = PASS, replace with above after configuring settings 
                    // client.Connect (Options.mailServer, 587, false);
                    client.Connect (Options.SMTPServer, 587, false);
                    // Note: only needed if the SMTP server requires authentication
                    // TEST - PASS - local with AuthOptions
                    // await client.AuthenticateAsync(Options.SMTPUser, Options.SMTPKey);
                    // TEST - PASS - remote with EmailSettings
                    await client.AuthenticateAsync(Options.SMTPusername, Options.SMTPpassword);
                    // send message and disconnect
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
        public Task Execute(string userName, string subject, string emailBody)
        {
            return SendEmailAsync(userName, subject, emailBody);   
        }
    }
}