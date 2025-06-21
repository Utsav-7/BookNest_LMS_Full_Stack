namespace LMS_Backend.LMS.Application.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string toEmail, string subject, string body);
        public Task SendUserRegistrationEmailAsync(string toEmail, string password);
        public Task SendStudentRegistrationEmailAsync(string toEmail, string studentName);
        public Task SendWishlistAvailableEmailAsync(string toEmail, string studentName, string bookTitle, int availableCopies);
    }
}