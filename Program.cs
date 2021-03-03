using System;
using System.IO;
using Newtonsoft.Json;
using Bluscream;
using System.Text;
using IniParser;
using IniParser.Model;

namespace MCLauncher2MultiMC
{
    class Program
    {
        internal static FileInfo VanillaLauncherProfilesJSON = new FileInfo(@"C:\Users\Shadow\AppData\Roaming\.minecraft\launcher_profiles.json");
        internal static DirectoryInfo MMCInstancesDir = new DirectoryInfo(@"C:\Users\Shadow\Downloads\MultiMC\instances\");
        internal static FileIniDataParser iniParser = new FileIniDataParser();
        internal const string defaultVersion = "latest-release"; internal const string defaultSnapshot = "latest-snapshot";
        static void Main(string[] args)
        {
            Console.WriteLine($"Reading {VanillaLauncherProfilesJSON.FullName.Quote()}");
            var launcherProfiles = LauncherProfiles.FromJson(VanillaLauncherProfilesJSON.ReadAllText());
            Console.WriteLine($"Loaded {launcherProfiles.Profiles.Count} profiles from {VanillaLauncherProfilesJSON.Name.Quote()}");
            foreach (var _profile in launcherProfiles.Profiles)
            {
                var profile = new LauncherProfile(_profile.Key, _profile.Value);
                Console.WriteLine($"Processing profile {profile.Data.Name} ({profile.Id}) ...");
                if (profile.Data.Type != "custom") continue;

                if (!profile.MMCInstance.Directory.Exists)
                {
                    Console.WriteLine($"Creating directory {profile.MMCInstance.Directory.FullName.Quote()}");
                    profile.MMCInstance.Directory.Create();
                }

                if (!profile.MMCInstance.Config.File.Exists)
                {
                    Console.WriteLine($"Creating file {profile.MMCInstance.Config.File.FullName.Quote()}");
                    profile.MMCInstance.Config.Data = new MMCInstanceConfig().iniData;
                }

                profile.MMCInstance.Config.Data.Global["name"] = (string.IsNullOrWhiteSpace(profile.Data.Name) ? profile.Data.Name : profile.Id);
                // var JavaPath = new FileInfo();
                if (profile.Data.JavaDir != null) profile.MMCInstance.Config.Data.Global["JavaPath"] = profile.Data.JavaDir.FullName.Replace("\\", "/");
                else profile.MMCInstance.Config.Data.Global["OverrideJavaLocation"] = "false";
                if (profile.Data.JavaArgs != null) profile.MMCInstance.Config.Data.Global["JvmArgs"] = profile.Data.JavaArgs;
                else profile.MMCInstance.Config.Data.Global["OverrideJavaArgs"] = "false";
                if (profile.Data.Created.HasValue) profile.MMCInstance.Config.Data.Global["JavaTimestamp"] = profile.Data.Created.Value.ToUnixTimeMilliseconds().ToString();
                if (profile.Data.LastUsed.HasValue) profile.MMCInstance.Config.Data.Global["lastLaunchTime"] = profile.Data.LastUsed.Value.ToUnixTimeMilliseconds().ToString();

                    // TODO: Convert RAM from JVMARGS
                profile.MMCInstance.Config.Save();
                

                    /*sb = new StringBuilder("public string " + item.KeyName + " { get; set; }");
                    if (!string.IsNullOrWhiteSpace(item.Value)) sb.Append(" = \"" + item.Value.ToString() + "\";");
                    sb.Print();*/
                    // new StringBuilder(" { \"" + item.KeyName + "\", \"" + item.Value + "\" },").Print();
                    // new StringBuilder("iniData.Global.AddKey(\"" + item.KeyName + "\", \"" + item.Value + "\");").Print();
            }
        }
    }
}
