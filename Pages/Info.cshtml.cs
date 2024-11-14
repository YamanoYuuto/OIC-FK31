using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace OIC_FK31.Pages
{
    public class InfoModel : PageModel
    {
        public string _DataTime { get; set; }
        public IActionResult OnGet([FromQuery] string DataTime)
        {
            _DataTime = DataTime;
            return Page();
        }

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
            public string email_confirm { get; set; }

            [Required(ErrorMessage = "電話番号を入力してください。")]
            public string phone { get; set; }

            [Required(ErrorMessage = "電話番号（再入力用）を入力してください。")]
            public string phone_confirm { get; set; }

            [Required(ErrorMessage = "郵便番号を入力してください。")]
            public string postal_code { get; set; }

            [Required(ErrorMessage = "都道府県を入力してください。")]
            public string prefecture { get; set; }

            [Required(ErrorMessage = "市区町村を入力してください。")]
            public string city { get; set; }

            [Required(ErrorMessage = "丁目・番地を入力してください。")]
            public string address { get; set; }

            [Required(ErrorMessage = "建物名・部屋番号を入力してください。")]
            public string building { get; set; }
        }
    }
}
