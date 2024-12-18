using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;

namespace OIC_FK31.Pages
{
    [Authorize(Roles = "Admin")]
    public class FacilityIndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        publicÅ@FacilityIndexModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public List<facility> Facility { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            var context = new ApplicationDbContext();
            Facility = await context.Facility.ToListAsync();
            return Page();
        }
    }
}
