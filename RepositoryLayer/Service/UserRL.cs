using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;
using RepositoryLayer.JwtToke;
using System.Text;
using System.Text.RegularExpressions;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        public readonly FundooNotesDBContext dbContext;
        public IConfiguration configuration;

        public UserRL(FundooNotesDBContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public UserEntity Register(UserModel newUser)
        {
            ValidateEmail(newUser.UserEmail);
            ValidatePassword(newUser.UserPassword);
            byte[] encriptedPassword = Encoding.UTF8.GetBytes(newUser.UserPassword);
            var userEntity = new UserEntity
            {
                UserName = newUser.UserName,
                UserEmail = newUser.UserEmail,
                UserContact = newUser.UserContact,
                UserPassword = Convert.ToBase64String(encriptedPassword),
                AddedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return userEntity;
        }

        public string Login(string userEmail, string userPassword)
        {
            ValidateEmail(userEmail);
            ValidatePassword(userPassword);
            string encriptedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(userPassword));
            JwtToken token = new JwtToken(configuration);

            var user = dbContext.Users.SingleOrDefault(u => u.UserEmail == userEmail && u.UserPassword == encriptedPassword);
            if (user != null)
            {
                return token.GenerateToken(user);
            }
            else
            {
                throw new InvalidOperationException("User not found or password is in correct");
            }
        }

        public bool ResetPassword(string userEmail, string newPassword)
        {
            ValidateEmail(userEmail);
            ValidatePassword(newPassword);
            string encriptedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(newPassword));
            var user = dbContext.Users.SingleOrDefault(u => u.UserEmail == userEmail);

            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            user.UserPassword = encriptedPassword;
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