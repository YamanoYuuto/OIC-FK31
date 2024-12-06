using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OIC_FK31.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public CalendarModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public bool AdminFlg { get; set; } = false;

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (await _userManager.IsInRoleAsync(user, "Admin") == true)
            {
                AdminFlg = true;
            }
            return Page();
        }
    }
}
