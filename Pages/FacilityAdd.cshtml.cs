using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using OIC_FK31.Data;
using System.Security.Claims;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace OIC_FK31.Pages
{
    [Authorize(Roles = "Admin")]
    public class FacilityAddModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IWebHostEnvironment _environment;
        [BindProperty]
        public facility FacilityAdd { get; set; }

        public FacilityAddModel(IWebHostEnvironment environment, UserManager<IdentityUser> userManager)
        {
            _environment = environment;
            _userManager = userManager;
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

        public async Task<IActionResult> OnPostAsync([Required(ErrorMessage ="ファイルが選択されていません")]IFormFile photofile)
        {
            ModelState.Remove("FacilityAdd.FacilityphotoPath");

            if (photofile != null)
            {
                var extension = Path.GetExtension(photofile.FileName).ToLower();
                if (extension != ".jpg")
                {
                    ModelState.AddModelError("FileEx", "ファイルは.jpgのみです。");
                }
            }
            if(FacilityAdd.OpeningTime > FacilityAdd.ClosingTime)
            {
                ModelState.AddModelError("TimeError", "開館・閉館時間を正しく入力してください");
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
