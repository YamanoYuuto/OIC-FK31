using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;

namespace OIC_FK31.Pages
{
    public class FacilityIndexModel : PageModel
    {
        public List<facility> Facility { get; set; }
        public async Task OnGetAsync()
        {
            var context = new ApplicationDbContext();
            Facility = await context.Facility.ToListAsync();
        }
    }
}
