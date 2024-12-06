using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Tls;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using Google;
using Microsoft.AspNetCore.Identity;

namespace OIC_FK31.Pages
{
    public class InfoModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public InfoModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public bool AdminFlg { get; set; } = false;

        public int facilityid { get; set; }
        public string sDataTime { get; set; }
        public string eDataTime { get; set; }

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
            [Compare("email", ErrorMessage = "���[���A�h���X����v���܂���B")]
            public string email_confirm { get; set; }

            [Required(ErrorMessage = "�d�b�ԍ�����͂��Ă��������B")]
            public string phone { get; set; }

            [Required(ErrorMessage = "�d�b�ԍ��i�ē��͗p�j����͂��Ă��������B")]
            [Compare("phone", ErrorMessage = "�d�b�ԍ�����v���܂���B")]
            public string phone_confirm { get; set; }

            [Required(ErrorMessage = "�X�֔ԍ�����͂��Ă��������B")]
            public string postal_code { get; set; }

            [Required(ErrorMessage = "�s���{������͂��Ă��������B")]
            public string prefecture { get; set; }

            [Required(ErrorMessage = "�s�撬������͂��Ă��������B")]
            public string city { get; set; }

            [Required(ErrorMessage = "���ځE�Ԓn����͂��Ă��������B")]
            public string address { get; set; }
            
            public string building { get; set; }
        }

        public async Task<IActionResult> OnGet([FromQuery] string id, string DataTime)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (await _userManager.IsInRoleAsync(user, "Admin") == true)
            {
                AdminFlg = true;
            }

            if (DataTime == null)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }

            facilityid = int.Parse(id);
            string[] word = DataTime.Split('"', '�`');
            sDataTime = word[1] + word[3];
            eDataTime = word[1] + word[4];
            return Page();
        }

        public IActionResult OnPostAsync([FromQuery] string id, string DataTime)
        {
            ModelState.Remove("building");
            if (ModelState.IsValid)
            {
                string[] word = DataTime.Split('"', '�`');
                sDataTime = word[1] + word[3];
                eDataTime = word[1] + word[4];
                string date = Input.last_name + "!" + Input.first_name + "!" + Input.email + "!" + Input.phone + "!" + Input.postal_code + "!" +
                    Input.prefecture + "!" + Input.city + "!" + Input.address + "!" + Input.building + "!" + int.Parse(id) + "!" + sDataTime + "!" + eDataTime;
                return RedirectToPage("/confirmation", new { Date = date });
            }
            return Page();
        }
    }
}
