using LMSAPI.Models;

namespace LMSAPI.Repository.Interface
{
    public interface IUser
    {
        User UserLogin(string userName, string password);
        bool Signup(User user);
    }
}
