using CommonLayer.Model;
using RepositoryLayer.Entitys;

namespace RepositoryLayer.Innterface
{
    public interface IUserRL
    {
        UserEntity Register(UserModel newUser);
        string Login(string userEmail, string userPassword);
        bool ResetPassword(string userEmail, string newPassword);

       
    }
}
