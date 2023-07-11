using LMSAPI.DAL;
using LMSAPI.Models;
using LMSAPI.Repository.Interface;
using System.Linq;

namespace LMSAPI.Repository.Service
{
    public class UserRepo : IUser
    {
        public ApplicationDbContext _dbContext;
        public UserRepo(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public User UserLogin(string userName, string password)
        {
            return _dbContext.User.FirstOrDefault(t => t.UserName == userName && t.Password == password);
        }
        public bool Signup(User user)
        {
            _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
