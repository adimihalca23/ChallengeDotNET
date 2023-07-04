using System.ComponentModel.DataAnnotations;

namespace ChallengeDotNET.Models
{
    public class User
    {
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than zero.")]
        public int UserId { get; private set; }
        public Password Password = new Password();

        public User(int userId)
        {
            if (userId < 1) throw new Exception("The value for userId must be greater than zero.");

            UserId = userId;
        }
    }
}
