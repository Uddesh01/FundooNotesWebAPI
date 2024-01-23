using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;

namespace BusinessLayer.Sevice
{
    public class UserBL : IUserBL
    {
        public readonly IUserRL iuserRL;

        public UserBL(IUserRL userRL)
        {
            iuserRL = userRL;
        }
        public UserEntity Register(UserModel newUser)
        {

            return iuserRL.Register(newUser);
        }

        public UserEntity Login(string userEmail, string userPassword)
        {
            return iuserRL.Login(userEmail, userPassword);
        }

        public bool ResetPassword(string userEmail, string newPassword)
        {
            return iuserRL.ResetPassword(userEmail, newPassword);
        }  
    }
}
