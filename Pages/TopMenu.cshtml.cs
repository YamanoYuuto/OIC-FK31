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

        public bool AdminFlg { get; set; } = false;

        public async Task<IActionResult> OnGetAsync()
        {
            //<IActionResult>‚É‚µ‚Ä
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
