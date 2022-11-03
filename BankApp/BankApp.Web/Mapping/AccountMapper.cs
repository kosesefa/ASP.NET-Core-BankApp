using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class AccountMapper:IAccountMapper
    {
        public Account Map(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance,

            };
        }
    }
}
