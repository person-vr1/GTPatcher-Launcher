using System.Diagnostics;
using System.Runtime.InteropServices;
using static Constants;

namespace GTPatcher_Launcher.Utilities
{
    public static class SteamHelper
    {
        public static int DownloadManifest(ulong manifestId, string directory, string steamUsername, bool isBeta)
        {
            if (isBeta)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var proc = Process.Start("DepotDownloader.exe", $"-app {APP_ID} -depot {DEPOT_ID} -manifest {manifestId.ToString()} -beta beta -username {steamUsername} -remember-password -dir \"{directory}\"");
                    proc.WaitForExit();
                    return proc.ExitCode;
                }
                else
                {
                    var proc = Process.Start("DepotDownloader", $"-app {APP_ID} -depot {DEPOT_ID} -manifest {manifestId.ToString()} -beta beta -username {steamUsername} -remember-password -dir \"{directory}\"");
                    proc.WaitForExit();
                    return proc.ExitCode;
                }
            }
            else
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var proc = Process.Start("DepotDownloader.exe", $"-app {APP_ID} -depot {DEPOT_ID} -manifest {manifestId.ToString()} -username {steamUsername} -remember-password -dir \"{directory}\"");
                    proc.WaitForExit();
                    return proc.ExitCode;
                }
                else
                {
                    var proc = Process.Start("DepotDownloader", $"-app {APP_ID} -depot {DEPOT_ID} -manifest {manifestId.ToString()} -username {steamUsername} -remember-password -dir \"{directory}\"");
                    proc.WaitForExit();
                    return proc.ExitCode;
                }                
            }
        }
    }
}