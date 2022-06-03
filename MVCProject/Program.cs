using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MVCProject;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);


startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app, app.Environment);

builder.Services.AddControllersWithViews();




// Configure the HTTP request pipeline.

