using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace OIC_FK31.Pages
{
    public class FacilityEditModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        [BindProperty]
        public facility Facility { get; set; }

        public FacilityEditModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
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
        public async Task<IActionResult> OnPostAsync(int? id, IFormFile? photofile)
        {
            ModelState.Remove("Facility.FacilityphotoPath");

            if(photofile != null)
            {
                var extension = Path.GetExtension(photofile.FileName).ToLower();
                if (extension != ".jpg")
                {
                    ModelState.AddModelError("FileEx", "ファイルは.jpgのみです。");
                }
            }
            if (Facility.OpeningTime > Facility.ClosingTime)
            {
                ModelState.AddModelError("TimeError", "開館・閉館時間を正しく入力してください");
            }

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

            if (photofile != null)
            {
                Facility.FacilityphotoPath = photofile.FileName;
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                var filepath = Path.Combine(uploadsFolder, photofile.FileName);
                var stream = new FileStream(filepath, FileMode.Create);
                await photofile.CopyToAsync(stream);
                facility.FacilityphotoPath = photofile.FileName;
            }

            facility.FacilityName = Facility.FacilityName;
            facility.FacilityAddress = Facility.FacilityAddress;
            facility.FacilityPhone = Facility.FacilityPhone;
            facility.OpeningTime = Facility.OpeningTime;
            facility.ClosingTime = Facility.ClosingTime;
            facility.FacilityPostCode = Facility.FacilityPostCode;
            

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
