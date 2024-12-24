using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OIC_FK31.Data;
using Org.BouncyCastle.Asn1.Cms;
using System.ComponentModel.DataAnnotations;

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

        public IList<time> time { get; set; } 

        public async Task<IActionResult> OnGetAsync([FromQuery][Required] string id)
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

            var context = new ApplicationDbContext();
            int iid = int.Parse(id);
            time = context.Time.Where(x => x.FacilityID == iid).ToList();

            return Page();
        }
    }
}
