using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.İnterfaces;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Data.Reporsitories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Set<Account>().Add(account);
            _context.SaveChanges();
        }
        public void Remove(Account account)
        {
            _context.Set<Account>().Remove(account);
            _context.SaveChanges();
        }
        public List<Account>GetAll()
        {
            return _context.Set<Account>().ToList();
        }
    }
}
