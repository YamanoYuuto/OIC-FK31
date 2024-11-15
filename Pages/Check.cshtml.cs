using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OIC_FK31.Data;

namespace FK_31.Pages
{
    public class CheckModel : PageModel
    {
        //_userManager関連を追加 23,27,29 + getに
        private readonly UserManager<IdentityUser> _userManager;

        public CheckModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public InputModel Input { get; set; }

        public class InputModel
        {
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

            [DataType(DataType.DateTime)]
            public DateTime starttime { get; set; }

            [DataType(DataType.DateTime)]
            public DateTime endtime { get; set; }


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

        public async Task<IActionResult> OnPostAsync()
        {      
            var context = new ApplicationDbContext();

            var Time = new time
            {
                FacilityID = Input.facilityid,
                StartTime = Input.starttime,
                EndTime = Input.endtime
            };

            context.Time.Add(Time);
            context.SaveChanges();
            
                var UserDatail = new userDetail
                {
                    UserID = _userManager.GetUserAsync(User).Id,
                    LastName = Input.last_name,
                    FirstName = Input.first_name,
                    Email = Input.email,
                    Phone = Input.phone,
                    PostalCode = Input.postal_code,
                    Prefecture = Input.prefecture,
                    City = Input.city,
                    Address = Input.address,
                    Building = Input.building
                };

            context.UserDetail.Add(UserDatail);
            context.SaveChanges();

            var Reservation = new reservation
            {
                UserDetailID = UserDatail.UserDetailID,
                TimeID = Time.TimeID,
                BookingDate=DateTime.Now
            };
            context.Reservation.Add(Reservation);
            context.SaveChanges();

            return Redirect("/Thank");
        }
    }
}
