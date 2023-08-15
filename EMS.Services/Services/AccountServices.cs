using EMS.Core.IRepo;
using EMS.Data.Helper;
using EMS.Data.Models.ViewModels;
using EMS.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepo _accountRepo;
        public AccountServices(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<DataResult> LoginAsync(LoginVM model)
        {
            var result = await _accountRepo.LoginAsync(model);
            return result;
        }

        public Task<DataResult> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult> RegisterAsync(RegisterVM model)
        {
            var result = await _accountRepo.RegisterAsync(model);
            return result;
        }
    }
}
