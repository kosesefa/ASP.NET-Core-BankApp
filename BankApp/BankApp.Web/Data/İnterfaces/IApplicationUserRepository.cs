using BankApp.Web.Data.Entities;
using System.Collections.Generic;

namespace BankApp.Web.Data.İnterfaces
{
    public interface IApplicationUserRepository
    {
        public List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
    }
}
