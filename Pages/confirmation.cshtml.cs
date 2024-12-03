using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OIC_FK31.Data;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApplication4.Pages
{
    public class confirmationModel : PageModel
    {
        //_userManager関連を追加 23,27,29 + getに
        private readonly UserManager<IdentityUser> _userManager;

        public confirmationModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string last_name { get; set; }

        public string first_name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string postal_code { get; set; }

        public string prefecture { get; set; }

        public string city { get; set; }

        public string address { get; set; }

        public string building { get; set; }

        public int facilityid { get; set; }
        public string facilityname { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime starttime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime endtime { get; set; }
        public async Task<IActionResult> OnGetAsync([FromRoute] string Date)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (Date != null)
            {
                try
                {
                    string[] date = Date.Split('!');
                    last_name = date[0];
                    first_name = date[1];
                    email = date[2];
                    phone = date[3];
                    postal_code = date[4];
                    prefecture = date[5];
                    city = date[6];
                    address = date[7];
                    building = date[8];
                    facilityid = int.Parse(date[9]);
                    starttime = DateTime.Parse(date[10]);
                    endtime = DateTime.Parse(date[11]);

                    ApplicationDbContext context = new ApplicationDbContext();
                    facilityname = context.Facility.Find(int.Parse(date[9])).FacilityName;
                }
                catch (Exception ex)
                {
                    return NotFound();
                }

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] string Date)
        {
            if (Date != null)
            {
                string[] date = Date.Split('!');
                last_name = date[0];
                first_name = date[1];
                email = date[2];
                phone = date[3];
                postal_code = date[4];
                prefecture = date[5];
                city = date[6];
                address = date[7];
                building = date[8];
                facilityid = int.Parse(date[9]);
                starttime = DateTime.Parse(date[10]);
                endtime = DateTime.Parse(date[11]);
            }
            else
            {
                return NotFound();
            }

            var context = new ApplicationDbContext();

            var Time = new time
            {
                FacilityID = facilityid,
                StartTime = starttime,
                EndTime = endtime
            };

            await context.Time.AddAsync(Time);
            await context.SaveChangesAsync();
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserDatail = new userDetail
            {
                UserID = userid,
                LastName = last_name,
                FirstName = first_name,
                Email = email,
                Phone = phone,
                PostalCode = postal_code,
                Prefecture = prefecture,
                City = city,
                Address = address,
                Building = building
            };

            await context.UserDetail.AddAsync(UserDatail);
            await context.SaveChangesAsync();

            var Reservation = new reservation
            {
                UserDetailID = UserDatail.UserDetailID,
                TimeID = Time.TimeID,
                BookingDate = DateTime.Now,
                Application = "なし",
                Number = 0
            };
            await context.Reservation.AddAsync(Reservation);
            await context.SaveChangesAsync();

            return RedirectToPage("/Thank", new { id = Reservation.ReservationID });
        }
    }
}
