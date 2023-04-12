using BlazorWasm1.Auth;
using BlazorWasm1.Services.Http;
using BlazorWasm1.Services.PostService;
using Microsoft.AspNetCore.Components.Authorization;
using WebApi.Services;
using IAuthService = BlazorWasm1.Services.IAuthService;
using IPostService = WebApi.Services.IPostService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IPostService, PostHttpClient>();
builder.Services.AddScoped<IPostServices, PostServices>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new System.Net.Http.HttpClient());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();