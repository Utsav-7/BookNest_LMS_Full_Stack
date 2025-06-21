namespace LMS_Backend.LMS.Infrastructure.Helpers
{
    public static class OtpStore
    {
        public static Dictionary<string, (int Otp, DateTime Expiration)> UserOtps { get; set; } = new();
    }
}