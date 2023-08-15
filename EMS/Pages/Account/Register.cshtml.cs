using EMS.Data.Models.ViewModels;
using EMS.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMS.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterVM AccountRegister {  get; set; }
        private readonly IAccountServices _accountServices;
        public RegisterModel(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
        if(ModelState.IsValid)
            {
                var result = await _accountServices.RegisterAsync(this.AccountRegister);
                if(result.IsSuccess)
                {
                    return RedirectToPage("/Account/Login");
                }
                else
                {
                    return Page();
                }

            }
            return Page();
        }
    }
}
