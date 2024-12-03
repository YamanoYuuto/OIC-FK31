using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using OIC_FK31.Data;
using System.Security.Claims;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Pages
{
    public class FacilityAddModel : PageModel
    {

        private readonly IWebHostEnvironment _environment;
        [BindProperty]
        public facility FacilityAdd { get; set; }

        public FacilityAddModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<IActionResult> OnPostAsync([Required(ErrorMessage ="�t�@�C�����I������Ă��܂���")]IFormFile photofile)
        {
            ModelState.Remove("FacilityAdd.FacilityphotoPath");

            if (photofile != null)
            {
                var extension = Path.GetExtension(photofile.FileName).ToLower();
                if (extension != ".jpg")
                {
                    ModelState.AddModelError("FileEx", "�t�@�C����.jpg�݂̂ł��B");
                }
            }
            if(FacilityAdd.OpeningTime > FacilityAdd.ClosingTime)
            {
                ModelState.AddModelError("TimeError", "�J�فE�َ��Ԃ𐳂������͂��Ă�������");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (photofile != null)
            {
                FacilityAdd.FacilityphotoPath = photofile.FileName;
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                var filepath = Path.Combine(uploadsFolder, photofile.FileName);
                var stream = new FileStream(filepath, FileMode.Create);
                await photofile.CopyToAsync(stream);
            }
            
            var context =new ApplicationDbContext();

            await context.Facility.AddAsync(FacilityAdd);
            await context.SaveChangesAsync();
            return Redirect("/FacilityIndex");
        }
    }
}
