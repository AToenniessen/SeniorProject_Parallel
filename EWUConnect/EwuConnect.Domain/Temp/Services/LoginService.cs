using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EwuConnect.Domain.Services
{
    public class LoginService : ILoginService
    {
        private ApplicationDbContext DbContext { get; }

        public LoginService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Login> AddLogin(Login userLogin)
        {
            DbContext.Logins.Add(userLogin);
            await DbContext.SaveChangesAsync();
            return userLogin;
        }
        public async Task<int> CheckLogin(Login userLogin)
        {
            Login foundLogin = await DbContext.Logins.SingleOrDefaultAsync(l => l.Email.Equals(userLogin.Email));
            if (foundLogin != null && foundLogin.Password.Equals(userLogin.Password))
                return foundLogin.Id;
            else 
                return -1;
        }

        public async Task<bool> DeleteLogin(int loginId)
        {
            Login foundLogin = await DbContext.Logins.FindAsync(loginId);

            if (foundLogin != null)
            {
                DbContext.Logins.Remove(foundLogin);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Login> UpdateLogin(Login userLogin)
        {
            DbContext.Logins.Update(userLogin);
            await DbContext.SaveChangesAsync();
            return userLogin;
        }
    }
}
