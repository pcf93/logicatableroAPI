using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Domain.Model;
using Cordelia.LoginRegister.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cordelia.LoginRegister.Infraestructure.Repository;

public class UserRepository : IUserRepository
{

    private readonly ApplicationContext _dbContext;

    public UserRepository (ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public DbSet<User> GetUserContext()
    {
        return _dbContext.User;
    }

    public void InsertUser(User user)
    {
        _dbContext.User.Add(user);
        _dbContext.SaveChanges();
    }

}
