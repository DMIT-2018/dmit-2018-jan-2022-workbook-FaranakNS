using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//supplied database connection due to the fact that we create this web app to use Indiviual accounts

//Added
//code retrieves the connection string from appsettings.json
//code retrives the ChinookDB connecting string
//var connectionStringChinook = builder.Configuration.GetConnectionString("ChinookDB");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//given
//register the supplied connecting string with the IservicesCollection(.Services)
//registers the connection string for Indiviual Accounts
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//added
//code the lofic to add our class library services to IServiceCollection
//one could do the regisrtation code here in Program.cs
//However,everytime a service class is added,you would be changing this file
//the implementation of the DbCntent and AddTransient(...) code in this example
//   will be done in an extention method will be coded inside the ChinookSystem class library
//the extentiion method will have a parameter:options.UseSqlServer()

builder.Services.ChinookSystemBackendDependencies(options =>
    options.UseSqlServer(connectionStringChinook)););
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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
