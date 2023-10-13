using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly.GetName().Name;

var defaultConnString = builder.Configuration.GetConnectionString("AutoStoreContext");

builder.Services.AddIdentityServer().AddConfigurationStore(options =>
{
    options.ConfigureDbContext = b =>
    b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));
}).AddOperationalStore(options =>
{
    options.ConfigureDbContext = b =>
    b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));

});
var app = builder.Build();

app.UseIdentityServer();

app.Run();