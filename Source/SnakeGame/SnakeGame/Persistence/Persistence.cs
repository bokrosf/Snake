using Microsoft.Maui.Storage;
using System.Threading.Tasks;

namespace SnakeGame.Persistence;

/// <summary>
/// Storing and accessing persisted data.
/// </summary>
public class Persistence : IPersistence
{
    private readonly PreferencesStorage preferences;
    
    /// <summary>
    /// Initializes a new instance of <see cref="Persistence"/> class with the specified preferences.
    /// </summary>
    /// <param name="preferences">Preferences.</param>
    public Persistence(IPreferences preferences)
    {
        this.preferences = new PreferencesStorage(preferences);
    }

    public Task<Settings?> LoadSettingsAsync()
    {
        return Task.FromResult(preferences.Settings);
    }

    public Task SaveSettingsAsync(Settings settings)
    {
        preferences.Settings = settings;
        return Task.CompletedTask;
    }
}
