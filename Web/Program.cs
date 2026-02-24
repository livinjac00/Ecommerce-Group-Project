using Web.Components;
using Web.Services;
using BackEnd;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register the UserCollection service
var userCollection = new UserCollection();
userCollection.Load();
builder.Services.AddSingleton(userCollection);

// Register and initialize the UserStorageInfo service
var userStorageInfo = new UserStorageInfo();
userStorageInfo.UserList.AddRange(userCollection.Users);
// Mock some shopping cart data for prototype visibility
userStorageInfo.ShoppingCart.Add(new Product("Modern Headphones", 149.99m, "Noise-cancelling over-ear headphones.", Guid.Parse("2b6041f5-1b94-4387-836b-fca872160072"), "Audio"));
userStorageInfo.ShoppingCart.Add(new Product("Mechanical Keyboard", 89.50m, "RGB backlit mechanical keyboard.", Guid.Parse("1524ea3d-779c-49c7-90e7-79f84273bc28"), "Accessories"));
builder.Services.AddSingleton(userStorageInfo);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios,
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
