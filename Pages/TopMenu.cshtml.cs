using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FK_31.Pages
{
    public class TopMenuModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<TopMenuModel> _logger;

        public TopMenuModel(SignInManager<IdentityUser> signInManager, ILogger<TopMenuModel> logger, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            //<IActionResult>‚É‚µ‚Ä
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            return Page();
        }
    }
}
