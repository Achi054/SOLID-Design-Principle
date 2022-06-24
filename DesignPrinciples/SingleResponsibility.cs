using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace DesignPrinciples
{
    /// <summary>
    /// Single Responsibility Principle (SRP)
    /// Every software module, class, struct or functions should have one responsibility.
    /// </summary>
    public class SingleResponsibility
    {
        // Bad
        public class SingleResponsibilityBad
        {
            public class LoginUser
            {

                private readonly SmtpClient smtpClient;

                public void Register(string email, string password)
                {
                    if (!ValidateEmail(email))
                    {
                        throw new ValidationException("Please pass a valid email.");
                    }

                    var customer = new { Email = email, Pasword = password };

                    SendWelcomeEmail(new MailMessage("abc@test.com", customer.Email) { Subject = "Welcome to your customized app!!" });
                }

                private void SendWelcomeEmail(MailMessage mailMessage)
                {
                    smtpClient.Send(mailMessage);
                }

                private bool ValidateEmail(string email)
                {
                    return email.Contains("@");
                }
            }
        }

        // Good
        public class SingleResponsibilityGood
        {
            public class EmailHandler
            {
                private readonly SmtpClient smtpClient;

                public void SendWelcomeEmail(MailMessage mailMessage)
                {
                    smtpClient.Send(mailMessage);
                }

                public bool ValidateEmail(string email)
                {
                    return email.Contains("@");
                }
            }

            public class DataProcessor
            {
                public bool AddUser(User user)
                {
                    // Add user to data source.

                    return default;
                }
            }

            public class User
            {
                private readonly EmailHandler emailHandler;
                private readonly DataProcessor dataProcessor;

                public User(EmailHandler emailHandler, DataProcessor dataProcessor)
                {
                    this.emailHandler = emailHandler;
                    this.dataProcessor = dataProcessor;
                }

                public string Email { get; set; }

                public string Password { get; set; }

                public void Register()
                {

                    if (!emailHandler.ValidateEmail(Email))
                    {
                        throw new ValidationException("Please pass a valid email.");
                    }

                    dataProcessor.AddUser(this);

                    emailHandler.SendWelcomeEmail(new MailMessage("abc@test.com", Email) { Subject = "Welcome to your customized app!!" });
                }
            }
        }
    }
}
