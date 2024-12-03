using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace OIC_FK31.Pages
{
    public class FacilityEditModel : PageModel
    {
        [BindProperty]
        public facility Facility { get; set; }
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
            Facility = facility;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var context = new ApplicationDbContext();
            var facility = await context.Facility.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }

            facility.FacilityName = Facility.FacilityName;
            facility.FacilityAddress = Facility.FacilityAddress;
            facility.FacilityPhone = Facility.FacilityPhone;
            facility.OpeningTime = Facility.OpeningTime;
            facility.ClosingTime = Facility.ClosingTime;
            facility.FacilityPostCode = Facility.FacilityPostCode;
            facility.FacilityphotoPath = Facility.FacilityphotoPath;
            

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Redirect("./FacilityIndex");
        }
    }
}
