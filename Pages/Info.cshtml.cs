using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace OIC_FK31.Pages
{
    public class InfoModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string First_Name { get; set; }

            public string Last_Name { get; set; }

            public string Email {  get; set; }

            public string Email_Confirm { get; set; }

            public string Phone {  get; set; }

            public string Phone_Confirm { get; set; }

            public string Postal_Code { get; set; }

            public string Prefecture { get; set; }

            public string City { get; set; }

            public string Address { get; set; }

            public string Building {  get; set; }
        }
        public void OnGet()
        {
        }


    }
}
