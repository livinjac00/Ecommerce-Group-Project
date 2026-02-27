using Blazored.LocalStorage;

public class LocalStorageManager
{
    private readonly ILocalStorageService _localStorage;

    public LocalStorageManager(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    // Your simplified "pull" method
    public async Task<string> GetUserId()
    {
        var userId = await _localStorage.GetItemAsync<string>("userId");
        return userId ?? "0";
    }

    public async Task SaveUserId(Guid userId)
    {
        await _localStorage.SetItemAsync("userId", userId.ToString());
    }
}
