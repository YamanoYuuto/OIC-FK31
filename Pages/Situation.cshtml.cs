using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;
using Org.BouncyCastle.Asn1.Cms;
using System.Security.Claims;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace OIC_FK31.Pages
{
    public class SituationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public string LoginUserId { get; set; }

        public SituationModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            LoginUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Page();
            //var context = new ApplicationDbContext();
            //var list = context.Reservation.Join(context.UserDetail, Resarvations => Resarvations.UserDetailID, userDetail => userDetail.UserDetailID, (Resarvations, userDetail) => new
            //{
            //    Resarvations.TimeID,
            //    userDetail.UserID
            //}).Join(context.Time, ReUs => ReUs.TimeID, Time => Time.TimeID, (ReUs, Time) => new 
            //{
            //    ReUs.UserID,
            //    Time.FacilityID,
            //    Time.StartTime,
            //    Time.EndTime,
            //}).Join(context.Facility, ReUsTi => ReUsTi.FacilityID, facility => facility.FacilityID, (ReUsTi, facility) => new 
            //{
            //    ReUsTi.UserID,
            //    ReUsTi.StartTime,
            //    ReUsTi.EndTime,
            //    facility.FacilityName,
            //    facility.FacilityphotoPath
            //}).ToList();

        }


    }
}

