using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OIC_FK31.Data;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;
using Microsoft.AspNetCore.Identity;

namespace FK_31.Pages
{
    public class ThankModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public ThankModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public bool AdminFlg { get; set; } = false;

        public string last_name { get; set; }
        public string first_name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime starttime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime endtime { get; set; }
        public string facilityname { get; set; }
        public async Task<IActionResult> OnGetAsync([FromRoute] int id)
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

            var context = new ApplicationDbContext();
            try
            {
                var reserve = await context.Reservation.FindAsync(id);
                if (reserve == null)
                    return NotFound();

                var userdetail = await context.UserDetail.FindAsync(reserve.UserDetailID);
                if (userdetail == null) 
                    return NotFound();

                last_name = userdetail.LastName;
                first_name = userdetail.FirstName;

                var time = await context.Time.FindAsync(reserve.TimeID);
                if (time == null)
                    return NotFound();

                starttime = time.StartTime;
                endtime = time.EndTime;

                var facility = await context.Facility.FindAsync(time.FacilityID);
                if (facility == null)
                    return NotFound();

                facilityname = facility.FacilityName;

                SendMailAsync(userdetail.Email, $"ñºëO: {last_name} {first_name}\n\rì˙éû: {starttime.ToString("M")}\n\ré{ê›ñº: {facilityname}\n\r éûä‘: {starttime.ToString("t")} Å` {endtime.ToString("t")}");
            }
            catch (Exception ex)
            {

            }
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            return Redirect("/TopMenu");
        }

        static async void SendMailAsync(string email, string text)
        {
            var messsage = new MimeKit.MimeMessage();

            messsage.From.Add(new MimeKit.MailboxAddress("ZONE BOOKER", "yuutoyuuto0407@gmail.com"));

            messsage.To.Add(new MimeKit.MailboxAddress("user", $"{email}"));

            messsage.Subject = "ó\ñÒì‡óe";

            var textPart = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain);
            textPart.Text = $@"{text}";


            messsage.Body = textPart;



            try
            {
                //oauthîFèÿ
                const string GMailAccount = "yuutoyuuto0407@gmail.com";

                var clientSecrets = new ClientSecrets
                {
                    ClientId = "939600869933-samjdak9qaendeu0suu5fiv8pl3319j8.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    DataStore = new FileDataStore("CredentialCacheFolder", false),
                    Scopes = new[] { "https://mail.google.com/" },
                    ClientSecrets = clientSecrets,
                    LoginHint = GMailAccount
                });


                var codeReceiver = new LocalServerCodeReceiver();
                var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

                var credential = await authCode.AuthorizeAsync(GMailAccount, CancellationToken.None);

                if (credential.Token.IsStale)
                    await credential.RefreshTokenAsync(CancellationToken.None);

                var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    Program program = new Program();
                    await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(oauth2);
                    await client.SendAsync(messsage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
