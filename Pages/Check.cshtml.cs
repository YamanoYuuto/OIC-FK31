using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OIC_FK31.Data;

namespace FK_31.Pages
{
    public class CheckModel : PageModel
    {
        //_userManagerŠÖ˜A‚ð’Ç‰Á 23,27,29 + get‚É
        private readonly UserManager<IdentityUser> _userManager;

        public CheckModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string last_name { get; set; }

            public string first_name { get; set; }

            public string email { get; set; }

            public string phone { get; set; }

            public string postal_code { get; set; }

            public string prefecture { get; set; }

            public string city { get; set; }

            public string address { get; set; }

            public string building { get; set; }
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var context = new ApplicationDbContext();
            context.UserDetail.Add(
                new userDetail
                {

                });
            return Redirect("/Thank");
        }
    }
}
