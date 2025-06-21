using System.Net.Mail;
using System.Net;
using LMS_Backend.LMS.Application.Interfaces;

namespace LMS_Backend.LMS.Infrastructure.Helpers
{
    public class EmailHelper : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"])
                {
                    Port = int.Parse(_configuration["EmailSettings:SmtpPort"]),
                    Credentials = new NetworkCredential(
                        _configuration["EmailSettings:SenderEmail"],
                        _configuration["EmailSettings:SenderPassword"]
                    ),
                    EnableSsl = true
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailSettings:SenderEmail"], _configuration["EmailSettings:SenderName"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine($"Email sent successfully to {toEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email Error: {ex.Message}");
                throw; 
            }
        }

        private const string ContainerEnd = @"
            <div style='text-align: center; margin-top: 30px;'>
                <p style='color: #7f8c8d; font-size: 14px;'>Best Regards,</p>
                <p style='color: #2c3e50; font-size: 16px; font-weight: bold;'>The BookNest Team</p>
                <div style='margin-top: 20px;'>
                    <img src='https://drive.google.com/uc?export=view&id=1J-OM4zr7GXGMuI6Hzl6pT8HOsAL98z5n' 
                         alt='Bacancy Logo'
                         style='width: 200px; height: auto; display: block; margin: 0 auto;' />
                </div>
            </div>
        </div>";


        public async Task SendUserRegistrationEmailAsync(string toEmail, string? password)
        {
            string emailSubject = "Welcome to BookNest - Your Digital Library Account";
            string emailBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                    <h2 style='color: #2c3e50; text-align: center;'>Welcome to BookNest</h2>
                    <p style='font-size: 18px; color: #34495e; text-align: center;'>
                        Your account has been successfully created in our BookNest - Library Management System.
                    </p>
                    <div style='background-color: #ffffff; padding: 20px; border-radius: 8px; 
                                box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1); text-align: center;'>
                        <p style='font-size: 16px;'><strong>Email:</strong> {toEmail}</p>
                        <p style='font-size: 16px;'><strong>Temporary Password:</strong> {password}</p>
                        <p style='color: #e74c3c; font-size: 14px;'>
                            <em>We recommend updating your password after first login for security.</em>
                        </p>
                    </div>
                    {ContainerEnd}";

            await SendEmailAsync(toEmail, emailSubject, emailBody);
        }

        public async Task SendStudentRegistrationEmailAsync(string toEmail, string studentName)
        {
            string emailSubject = "Welcome to BookNest - Your Student Account";
            string emailBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                    <h2 style='color: #2c3e50; text-align: center;'>Welcome to BookNest, {studentName}!</h2>
                    
                    <p style='font-size: 18px; color: #34495e; text-align: center;'>
                        BookNest is your gateway to a world of knowledge, offering a vast collection of books 
                        and resources to support your academic journey.
                    </p>
                    
                    <div style='background-color: #ffffff; padding: 20px; border-radius: 8px; 
                                box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1); margin: 20px 0;'>
                        <p style='font-size: 16px; text-align: center;'>
                            <strong>Your registered email:</strong> {toEmail}
                        </p>
                        <p style='color: #e74c3c; font-size: 14px; text-align: center; margin-top: 15px;'>
                            You'll be prompted to set your password when you first login to the system.
                        </p>
                    </div>
                    
                    <p style='font-size: 16px; color: #34495e; text-align: center;'>
                        With BookNest, you can:
                    </p>
                    <ul style='font-size: 15px; color: #34495e; max-width: 400px; margin: 0 auto;'>
                        <li>Browse our extensive digital library collection</li>
                        <li>Borrow e-books and access online resources</li>
                        <li>Track your reading history and preferences</li>
                        <li>Receive personalized book recommendations</li>
                    </ul>
                    
                    <p style='font-size: 16px; color: #34495e; text-align: center; margin-top: 20px;'>
                        We're excited to have you join our community of readers and learners!
                    </p>
                    
                    <div style='margin-top: 30px; text-align: center; font-size: 14px; color: #7f8c8d;'>
                        <p>If you didn't request this account, please contact our support team immediately.</p>
                    </div>
                    {ContainerEnd}";

            await SendEmailAsync(toEmail, emailSubject, emailBody);
        }

        public async Task SendWishlistAvailableEmailAsync(string toEmail, string studentName, string bookTitle, int availableCopies)
        {
            string emailSubject = $"{bookTitle} is now available at BookNest!";

            string availabilityMessage = availableCopies == 1
                ? "Hurry! Only 1 copy remains available."
                : $"Hurry! Only {availableCopies} copies remain available.";

            string emailBody = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50; text-align: center;'>Good news, {studentName}!</h2>
            
                        <p style='font-size: 18px; color: #34495e; text-align: center;'>
                            The book you wished for is now available in our library.
                        </p>
            
                        <div style='background-color: #f8f9fa; padding: 20px; border-radius: 8px; 
                                    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1); margin: 20px 0; text-align: center;'>
                            <h3 style='color: #2980b9; margin-top: 0;'>{bookTitle}</h3>
                            <p style='font-size: 16px;'>
                                <strong>Status:</strong> Available for borrowing
                            </p>
                            <p style='color: {(availableCopies < 3 ? "#e74c3c" : "#27ae60")}; font-weight: bold;'>
                                {availabilityMessage}
                            </p>
                            <a href='https://yourlibrarydomain.com/books/details' 
                               style='display: inline-block; background-color: #3498db; color: white; 
                                      padding: 10px 20px; text-decoration: none; border-radius: 5px; 
                                      margin-top: 15px;'>
                                Borrow Now
                            </a>
                        </div>
            
                        <p style='font-size: 16px; color: #34495e; text-align: center;'>
                            To secure your copy:
                        </p>
                        <ol style='font-size: 15px; color: #34495e; max-width: 400px; margin: 0 auto;'>
                            <li>Login to your BookNest account</li>
                            <li>Visit the book details page</li>
                            <li>Click 'Borrow' to reserve your copy</li>
                            <li>Collect from library within 24 hours</li>
                        </ol>
            
                        <div style='margin-top: 30px; text-align: center; font-size: 14px; color: #7f8c8d;'>
                            <p>This notification was sent because you added this book to your wishlist.</p>
                            <p>You can manage your wishlist notifications in your account settings.</p>
                        </div>
                    </div>";

            await SendEmailAsync(toEmail, emailSubject, emailBody);
        }
    }
}