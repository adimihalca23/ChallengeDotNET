using System.Text;
using XSystem.Security.Cryptography;

namespace ChallengeDotNET.Models
{
    public class Password
    {
        public string? Value { get; set; }
        public bool IsValid { get; private set; } = false;

        /// <summary>
        /// Generate a one time password(OTP) based on user id and and current date time which is valid for up to 30 seconds.
        /// </summary>
        /// <returns>
        /// Returns a 4 digits password.
        /// </returns>
        public string GenerateOneTimePassword(int userId, DateTime dateTimeWhenPasswordCreated)
        {
            string combinedUserIdAndDate = userId.ToString() + dateTimeWhenPasswordCreated.ToString("ddMMyyyyHHmmss");

            byte[] dataBytes = Encoding.UTF8.GetBytes(combinedUserIdAndDate);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashBytes = sha256.ComputeHash(dataBytes);

            long passwordValue = BitConverter.ToInt64(hashBytes, 0);
            string password = Math.Abs((passwordValue % 10000)).ToString("D4");

            IsValid = true;
            SetPasswordInvalid();

            return password;
        }

        private async Task SetPasswordInvalid()
        {
            const double passwordValability = 30;

            await Task.Delay(TimeSpan.FromSeconds(passwordValability));
            IsValid = false;
        }
    }
}
