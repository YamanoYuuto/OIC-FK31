using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OIC_FK31.Data;
using System.Linq;

namespace OIC_FK31.Pages
{
    public class CancelModel : PageModel
    {

        public async Task<IActionResult>  OnGet([FromQuery] string id)
        {
            var context = new ApplicationDbContext();
            
            var reservation = context.Reservation.Single(x => x.ReservationID == int.Parse(id));
            var time = context.Time.Single(x => x.TimeID == reservation.TimeID);
            var userdetail = context.UserDetail.Single(x => x.UserDetailID == reservation.UserDetailID);
            context.Reservation.Remove(reservation);
            context.Time.Remove(time);
            context.UserDetail.Remove(userdetail);
            context.SaveChanges();
            context.Dispose();
            return Redirect("/Situation");
        }
    }
}
