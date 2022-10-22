using DataAcces.DataSixdegreesit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaTecnica.Configurations;
using Services.Configurations;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment Environment = builder.Environment;
// Add services to the container.

builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
builder.Services.AddControllers();


// App configuration
//builder.Services.Configure<AppConfiguration>(Configuration);


//Conexión con la base de datos y manejo de roles y usuarios
var sqlConn = Configuration.GetConnectionString("serverConnection");

builder.Services.AddDbContext<PruebaSDContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("serverconnectionsixdegreesit"));
});

//Se agrega validacion de json web token
//builder.Services.AddAuthentication()
//    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = Configuration.GetConnectionString("serverDomain"),
//        ValidAudience = Configuration.GetConnectionString("serverDomain"),
//        IssuerSigningKey = new SymmetricSecurityKey(
//       Encoding.UTF8.GetBytes(Configuration.GetConnectionString("Llave_secreta").ToString())),
//        ClockSkew = TimeSpan.Zero
//    });

builder.Services.AddAuthorization(options => { });
//Se agregan diferentes servicios incluidos en capeta Configuration
builder.Services.AddRepositories()
        .AddSwagger()
        .AddSegurity();
//.AddCors();
builder.Services.AddMvcCore()
    .AddAuthorization()
    .AddApiExplorer();
builder.Services.AddHttpContextAccessor();


/*==========================================================================================================*/

var app = builder.Build();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
// Configure the HTTP request pipeline.
if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}




app.UseAuthentication();

app.UseStaticFiles();

app.UseDefaultFiles();
//control de cache
app.UseMiddleware<NoCacheMiddleware>();
//configuracion Swagger Nswag
app.ConfigureSwagger();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//////////app.MapControllers();l de net6

app.Run();