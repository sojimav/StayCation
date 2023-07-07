using Hotel.Helpers;
using Hotel.Interface;


var builder = WebApplication.CreateBuilder(args);
/*Data Source=LAPTOP-LPLOFKEO;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False*/
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFileHandler, FileHandler>();
builder.Services.AddScoped<IDataHandler, DataHandler>(placeHolder => new DataHandler("Data Source=localhost;DATABASE=HotelDB;Integrated Security=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
