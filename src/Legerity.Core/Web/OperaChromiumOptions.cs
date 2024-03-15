using System;
using System.Runtime.InteropServices;

namespace Legerity.Web;

public class OperaChromiumOptions : ChromeOptions
{
    public OperaChromiumOptions(string binaryLocation = default)
    {
        BinaryLocation = DetermineBinaryLocation(binaryLocation);
    }

    /// <inheritdoc />
    public sealed override string BinaryLocation
    {
        get => base.BinaryLocation;
        set => base.BinaryLocation = value;
    }

    private string DetermineBinaryLocation(string binaryLocation)
    {
        if (!string.IsNullOrWhiteSpace(binaryLocation))
        {
            return binaryLocation;
        }

        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        if (isWindows)
        {
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return $@"{userPath}\AppData\Local\Programs\Opera\opera.exe";
        }

        var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        if (isLinux)
        {
            return "/usr/bin/opera";
        }

        var isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        if (isMac)
        {
            return "/Applications/Opera.app/Contents/MacOS/Opera";
        }

        throw new PlatformNotSupportedException("The current operating system is not supported.");
    }
}
