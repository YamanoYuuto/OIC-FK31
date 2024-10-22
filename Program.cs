using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using OIC_FK31.Data;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapGet("/", () => Results.Redirect("/Identity/Account/Login"));

//google oauth--------------------------------------------------------------------------
//const string GMailAccount = "yuutoyuuto0407@gmail.com";

//var clientSecrets = new ClientSecrets
//{
//    ClientId = "939600869933-samjdak9qaendeu0suu5fiv8pl3319j8.apps.googleusercontent.com",
//    ClientSecret = "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"
//};

//var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
//{
//    DataStore = new FileDataStore("CredentialCacheFolder", false),
//    Scopes = new[] { "https://mail.google.com/" },
//    ClientSecrets = clientSecrets,
//    LoginHint = GMailAccount
//});

//var codeReceiver = new LocalServerCodeReceiver();
//var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

//var credential = await authCode.AuthorizeAsync(GMailAccount, CancellationToken.None);

//if (credential.Token.IsStale)
//    await credential.RefreshTokenAsync(CancellationToken.None);

//var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);
//SaslMechanismOAuth2 o = oauth2;
//-------------------------------------------------------------------------------

app.Run();
