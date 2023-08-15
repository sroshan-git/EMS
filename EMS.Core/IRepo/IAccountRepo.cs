using EMS.Data.Helper;
using EMS.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.IRepo
{
    public interface IAccountRepo
    {
        Task<DataResult> LoginAsync(LoginVM model);
        Task<DataResult> RegisterAsync(RegisterVM model);
        Task<DataResult> LogoutAsync();
    }
}
