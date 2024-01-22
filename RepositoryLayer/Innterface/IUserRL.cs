using CommonLayer.Model;

namespace RepositoryLayer.Innterface
{
    public interface IUserRL
    {
        UserEntity Register(UserModel newUser);
        UserEntity Login(string userEmail, string userPassword);
        bool ResetPassword(string userEmail, string newPassword);
    }
}
