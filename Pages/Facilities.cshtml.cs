using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIC_FK31.Data;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace OIC_FK31.Pages
{
    public class FacilitiesModel : PageModel
    {
        public IList<facility> Facilities { get; set; } = default!;
        public async Task OnGetAsync()
        {
            var context = new ApplicationDbContext();
            if(context.Facility.Count() == 0)
            {
                context.Facility.AddRange(
                    new facility
                    {
                        FacilityName = "ã“ìŽs‘‡‘ÌˆçŠÙ",
                        OpeningTime = DateTime.Parse("08:00"),
                        ClosingTime = DateTime.Parse("19:00"),
                        FacilityAddress = "‘åã•{ã“ìŽsÎ“c19-03",
                        FacilityPhone = "000-0000-0000",
                        FacilityPostCode = "599-0221",
                    },
                    new facility
                    {
                        FacilityName = "‘åãî•ñƒRƒ“ƒsƒ…[ƒ^ê–åŠwZ",
                        OpeningTime = DateTime.Parse("08:00"),
                        ClosingTime = DateTime.Parse("20:00"),
                        FacilityAddress = "‘åã•{ã–{’¬",
                        FacilityPhone = "123-1234-1234",
                        FacilityPostCode = "135-2468",
                    });
                context.SaveChanges();
            }
            var ficility = context.Facility;
            //if (!string.IsNullOrEmpty(MovieGenre))
            //{
            //    movies = movies.Where(x => x.Genre == MovieGenre);
            //}
            
            Facilities = await ficility.ToListAsync();
        }
    }
}
