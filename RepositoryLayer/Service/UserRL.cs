using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;
using RepositoryLayer.JwtToke;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly FundooNotesDBContext dbContext;
        private IConfiguration configuration;

        public UserRL(FundooNotesDBContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public UserEntity Register(UserModel newUser)
        {
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
    }
}