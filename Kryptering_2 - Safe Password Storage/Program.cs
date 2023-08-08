using Kryptering_2___Safe_Password_Storage.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Setting up Depencency Injection
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(MockGenericRepository<>));
builder.Services.AddSingleton(typeof(IPasswordRepository), typeof(MockPasswordRepository));

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Getting injected services
var genericRepository = provider.GetRequiredService(typeof(IGenericRepository<>)); 
var passwordRepository = provider.GetRequiredService(typeof(IPasswordRepository)); 

