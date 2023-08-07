﻿using Kryptering_1___Hashing;
using Kryptering_1___Hashing.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IHashManager, HashManager>();

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
IHashManager hashManager = provider.GetRequiredService<IHashManager>();

GUIController gui = new GUIController(hashManager);

gui.ShowMainMenu();
