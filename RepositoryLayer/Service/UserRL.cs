using System.Text.RegularExpressions;
using CommonLayer.Model;
using RepositoryLayer.Innterface;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        public readonly FundooNotesDBContext dbContext;

        public UserRL(FundooNotesDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserEntity Register(UserModel newUser)
        {
            ValidateEmail(newUser.UserEmail);
            ValidatePassword(newUser.UserPassword);

            var userEntity = new UserEntity
            {
                UserName = newUser.UserName,
                UserEmail = newUser.UserEmail,
                UserPassword = newUser.UserPassword,
                UserContact = newUser.UserContact,
                AddedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return userEntity;
        }

        public UserEntity Login(string userEmail, string userPassword)
        {
            ValidateEmail(userEmail);
            ValidatePassword(userPassword);

            var user = dbContext.Users.SingleOrDefault(u => u.UserEmail == userEmail && u.UserPassword == userPassword);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }
            return user;
        }

        public bool ResetPassword(string userEmail, string newPassword)
        {
            ValidateEmail(userEmail);
            ValidatePassword(newPassword);

            var user = dbContext.Users.SingleOrDefault(u => u.UserEmail == userEmail);

            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            user.UserPassword = newPassword;
            user.UpdatedOn = DateTime.UtcNow;

            dbContext.SaveChanges();

            return true;
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