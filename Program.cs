using Syncfusion.Blazor;
using TodoList;
using TodoList.Adaptor;
using TodoList.Components;
using TodoList.Repository;
using TodoList.Services;

// Add custom services to the container.
DotEnv.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
//Console.WriteLine(Environment.GetEnvironmentVariable("TEST"));

var builder = WebApplication.CreateBuilder(args);

// Add custom services to the container.
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<TodoRepository>();
builder.Services.AddScoped<TodoAdaptor>();
builder.Services.AddSyncfusionBlazor();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
