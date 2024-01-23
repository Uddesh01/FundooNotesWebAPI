using CommonLayer.Model;
using RepositoryLayer.Entitys;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        UserEntity Register(UserModel newUser);
        UserEntity Login(string userEmail, string userPassword);
        bool ResetPassword(string userEmail, string newPassword);

    }
}
