using Microsoft.Maui.Storage;
using System.Runtime.CompilerServices;

namespace SnakeGame.Persistence;

/// <summary>
/// Persists data in preferences. Defines methods for saving and retrieving data.
/// </summary>
public class PreferencesStorage
{
    private IPreferences preferences;

    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesStorage"/> class with the specified preferences instance.
    /// </summary>
    /// <param name="preferences">Preferences.</param>
    public PreferencesStorage(IPreferences preferences)
    {
        this.preferences = preferences;
    }

    /// <summary>
    /// Game and movement settings.
    /// </summary>
    public Settings? Settings
    {
        get => Get<Settings?>(null);
        set => Set(value);
    }

    private T Get<T>(T defaultValue, [CallerMemberName] string key = "") => preferences.Get(key, defaultValue);

    private void Set<T>(T value, [CallerMemberName] string key = "") => preferences.Set(key, value);
}
