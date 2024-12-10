using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace OIC_FK31.Pages
{
    [Authorize(Roles = "Admin")]
    public class FacilityDeleteModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public FacilityDeleteModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public facility Facilities { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var context = new ApplicationDbContext();
            var facility = await context.Facility.FindAsync(id);

            if (facility == null)
            {
                return NotFound();
            }
            Facilities = facility;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var context = new ApplicationDbContext();
            if (id == null)
            {
                return NotFound();
            }

            var facility = await context.Facility.FindAsync(id);
            if (facility != null)
            {
                
                context.Facility.Remove(facility);
                await context.SaveChangesAsync();
            }

            return Redirect("./FacilityIndex");
        }
    }
}
