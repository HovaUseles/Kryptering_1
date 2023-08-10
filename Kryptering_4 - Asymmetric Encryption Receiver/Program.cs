using Kryptering_4___Asymmetric_Encryption_Receiver.GUI.Controllers;
using Kryptering_4___Asymmetric_Encryption_Receiver.GUI.Utilities;
using Kryptering_4___Asymmetric_Encryption_Receiver.Managers;
using Kryptering_4___Asymmetric_Encryption_Receiver.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient(typeof(IDecryptionService), typeof(XMLDecryptionService));

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
IDecryptionService decryptionService = provider.GetRequiredService<IDecryptionService>();

// Initializing manager and binding to controller
DecryptionViewController decryptionViewController = new DecryptionViewController(new DecryptionManager(decryptionService));

// Displaying first View
decryptionViewController.StartMenu();