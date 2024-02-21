using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;
using System.Text.RegularExpressions;

namespace BusinessLayer.Sevice
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;

        public UserBL(IUserRL userRL)
        {
            iuserRL = userRL;
        }
        public UserEntity Register(UserModel newUser)
        {
            ValidateEmail(newUser.UserEmail);
            ValidatePassword(newUser.UserPassword);
            return iuserRL.Register(newUser);
        }

        public string Login(string userEmail, string userPassword)
        {
            ValidateEmail(userEmail);
            ValidatePassword(userPassword);
            return iuserRL.Login(userEmail, userPassword);
        }

        public bool ResetPassword(string userEmail, string newPassword)
        {
            ValidatePassword(newPassword);
            return iuserRL.ResetPassword(userEmail, newPassword);
        }

        private void ValidateEmail(string email)
        {
            string regexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (!Regex.IsMatch(email, regexPattern))
            {
                throw new ArgumentException("Invalid email format");
            }
        }
        private void ValidatePassword(string password)
        {
            string regexPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$";
            if (!Regex.IsMatch(password, regexPattern))
            {
                throw new ArgumentException("Invalid password format");
            }
        }
    }
}
