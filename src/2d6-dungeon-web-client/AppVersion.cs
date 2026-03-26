using System.Reflection;

namespace c5m._2d6Dungeon.web;

public static class AppVersion
{
    private static readonly string _display = BuildDisplay();

    public static string Display => _display;

    private static string BuildDisplay()
    {
        var infoVersion = typeof(AppVersion).Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion;

        if (!string.IsNullOrEmpty(infoVersion))
            return $"v{infoVersion}";

        var version = typeof(AppVersion).Assembly.GetName().Version;
        return version is not null ? $"v{version.Major}.{version.Minor}.{version.Build}" : "vunknown";
    }
}
