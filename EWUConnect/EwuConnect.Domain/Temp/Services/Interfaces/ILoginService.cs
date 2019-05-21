using EwuConnect.Domain.Models.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Login> AddLogin(Login userLogin);
        Task<int> CheckLogin(Login userLogin);
        Task<Login> UpdateLogin(Login userLogin);
        Task<bool> DeleteLogin(int loginId);
    }
}