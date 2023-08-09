using Kryptering_2___Safe_Password_Storage.GUI.Utilities;
using Kryptering_2___Safe_Password_Storage.GUI.Controllers;
using Kryptering_2___Safe_Password_Storage.Managers;
using Kryptering_2___Safe_Password_Storage.Repositories;
using Kryptering_2___Safe_Password_Storage.Repositories.Interfaces;
using Kryptering_2___Safe_Password_Storage.Services;
using Kryptering_2___Safe_Password_Storage.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(typeof(IUserRepository), typeof(MockUserRepository));
builder.Services.AddSingleton(typeof(IPasswordRepository), typeof(MockPasswordRepository));
builder.Services.AddTransient(typeof(ISaltService), typeof(RandomSaltService));


// Switch between Standard Hash and PBKDF2 here
bool usePBKDF = false;
if (usePBKDF)
{
    builder.Services.AddTransient(typeof(IHashService), typeof(PBKDF2HashService)); // PBKDF2 Hash
}
else
{
    builder.Services.AddTransient(typeof(IHashService), typeof(SingleHashService)); // Standard Hash
}

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
IUserRepository userRepository = provider.GetRequiredService<IUserRepository>(); 
var passwordRepository = provider.GetRequiredService<IPasswordRepository>(); 
var saltService = provider.GetRequiredService<ISaltService>(); 
var hashService = provider.GetRequiredService<IHashService>();

// Constructing user manager with injected services
IUserManager userManager = new UserManager(saltService, hashService, userRepository, passwordRepository);

// Assigning User manager to UserGUI Controller
UserGUIController.userManager = userManager;

// Displaying first View
ViewRenderer.RenderView(UserGUIController.Index());