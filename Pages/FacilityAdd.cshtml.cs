using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OIC_FK31.Data;
using System.Security.Claims;

namespace OIC_FK31.Pages
{
    public class FacilityAddModel : PageModel
    {
        [BindProperty]
        public facility FacilityAdd { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var context =new ApplicationDbContext();

            await context.Facility.AddAsync(FacilityAdd);
            await context.SaveChangesAsync();
            return Redirect("/FacilityIndex");
        }
    }
}
