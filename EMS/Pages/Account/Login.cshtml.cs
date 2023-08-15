using EMS.Data.Models.ViewModels;
using EMS.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMS.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginVM Account { get; set; }
        private readonly IAccountServices _accountServices;
        public LoginModel(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _accountServices.LoginAsync(this.Account);
            if (result.IsSuccess)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
