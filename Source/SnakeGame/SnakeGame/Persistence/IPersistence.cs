using System.Threading.Tasks;

namespace SnakeGame.Persistence;

/// <summary>
/// Defines methods for accessing stored information.
/// </summary>
public interface IPersistence
{
    /// <summary>
    /// Loads the stored settings if there is any; otherwise <see langword="null"/>.
    /// </summary>
    Task<Settings?> LoadSettingsAsync();

    /// <summary>
    /// Stores the specified settings.
    /// </summary>
    /// <param name="settings">Game and movement settings.</param>
    Task SaveSettingsAsync(Settings settings);
}
