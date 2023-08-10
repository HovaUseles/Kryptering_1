using Kryptering_3___Symmetric_Encryption.GUI.Controllers;
using Kryptering_3___Symmetric_Encryption.GUI.Utilities;
using Kryptering_3___Symmetric_Encryption.Managers;
using Kryptering_3___Symmetric_Encryption.Services;
using Kryptering_3___Symmetric_Encryption.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient(typeof(ICryptoService), typeof(CryptoService));
builder.Services.AddTransient(typeof(IHexConverterService), typeof(HexConverterService));

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
ICryptoService cryptoService = provider.GetRequiredService<ICryptoService>();
IHexConverterService hexConverterService = provider.GetRequiredService<IHexConverterService>();

// Initializing manager and binding to controller
EncrypterController.encryptionManager = new EncryptionManager(cryptoService, hexConverterService);

// Displaying first View
ViewRenderer.RenderView(EncrypterController.Index());