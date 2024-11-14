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
          
            [Required(ErrorMessage = "�� (Last Name)����͂��Ă��������B")]
            public string last_name { get; set; }

            [Required(ErrorMessage = "�� (First Name)����͂��Ă��������B")]
            public string first_name { get; set; }

            [Required(ErrorMessage = "���[���A�h���X����͂��Ă��������B")]
            [EmailAddress]
            public string email { get; set; }

            [Required(ErrorMessage = "���[���A�h���X�i�ē��͗p�j����͂��Ă��������B")]
            [EmailAddress]
            public string email_confirm { get; set; }

            [Required(ErrorMessage = "�d�b�ԍ�����͂��Ă��������B")]
            public string phone { get; set; }

            [Required(ErrorMessage = "�d�b�ԍ��i�ē��͗p�j����͂��Ă��������B")]
            public string phone_confirm { get; set; }

            [Required(ErrorMessage = "�X�֔ԍ�����͂��Ă��������B")]
            public string postal_code { get; set; }

            [Required(ErrorMessage = "�s���{������͂��Ă��������B")]
            public string prefecture { get; set; }

            [Required(ErrorMessage = "�s�撬������͂��Ă��������B")]
            public string city { get; set; }

            [Required(ErrorMessage = "���ځE�Ԓn����͂��Ă��������B")]
            public string address { get; set; }

            [Required(ErrorMessage = "�������E�����ԍ�����͂��Ă��������B")]
            public string building { get; set; }
        }
    }
}
