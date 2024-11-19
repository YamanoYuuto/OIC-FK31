using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Tls;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using Google;

namespace OIC_FK31.Pages
{
    public class InfoModel : PageModel
    {
        public int facilityid { get; set; }
        public string sDataTime { get; set; }
        public string eDataTime { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        
        public class InputModel
        {
          
            [Required(ErrorMessage = "姓 (Last Name)を入力してください。")]
            public string last_name { get; set; }

            [Required(ErrorMessage = "名 (First Name)を入力してください。")]
            public string first_name { get; set; }

            [Required(ErrorMessage = "メールアドレスを入力してください。")]
            [EmailAddress]
            public string email { get; set; }

            [Required(ErrorMessage = "メールアドレス（再入力用）を入力してください。")]
            [EmailAddress]
            [Compare("email", ErrorMessage = "メールアドレスが一致しません。")]
            public string email_confirm { get; set; }

            [Required(ErrorMessage = "電話番号を入力してください。")]
            public string phone { get; set; }

            [Required(ErrorMessage = "電話番号（再入力用）を入力してください。")]
            [Compare("phone", ErrorMessage = "電話番号が一致しません。")]
            public string phone_confirm { get; set; }

            [Required(ErrorMessage = "郵便番号を入力してください。")]
            public string postal_code { get; set; }

            [Required(ErrorMessage = "都道府県を入力してください。")]
            public string prefecture { get; set; }

            [Required(ErrorMessage = "市区町村を入力してください。")]
            public string city { get; set; }

            [Required(ErrorMessage = "丁目・番地を入力してください。")]
            public string address { get; set; }

            public string building { get; set; }
        }

        public IActionResult OnGet([FromQuery] string id, string DataTime)
        {
            facilityid = int.Parse(id);
            string[] word = DataTime.Split('"', '～');
            sDataTime = word[1] + word[3];
            eDataTime = word[1] + word[4];
            return Page();
        }

        public IActionResult OnPostAsync([FromQuery] string id, string DataTime)
        {
            string[] word = DataTime.Split('"', '～');
            sDataTime = word[1] + word[3];
            eDataTime = word[1] + word[4];
            string date = Input.last_name + "!" + Input.first_name + "!" + Input.email + "!" + Input.phone + "!" + Input.postal_code + "!" +
                Input.prefecture + "!" + Input.city + "!" + Input.address + "!" + Input.building + "!" + int.Parse(id) + "!" + sDataTime + "!" + eDataTime;
            return RedirectToPage("/Check", new {Date = date});
        }
    }
}
