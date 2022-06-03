using Finbuckle.MultiTenant;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMultiTenant<TenantInfo>()
    .WithBasePathStrategy(options => options.RebaseAspNetCorePathBase = true)
    .WithConfigurationStore();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseMultiTenant();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

public partial class Program { }