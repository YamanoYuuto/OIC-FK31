using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace OIC_FK31.Pages
{
    public class FacilityDeleteModel : PageModel
    {
        public facility Facilities { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
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
