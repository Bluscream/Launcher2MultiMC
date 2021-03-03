namespace MCLauncher2MultiMC
{
    using Bluscream;
    using IniParser;
    using IniParser.Model;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public partial class MMCInstance
    {
        public LauncherProfile Profile { get; set; }
        public DirectoryInfo Directory { get; set; }
        public Config Config { get; set; }
        // public string Name { get { return this.Config.Data.Global["name"]; } }
        public MMCInstance(LauncherProfile profile, DirectoryInfo directory, FileIniDataParser fileIniDataParser = null)
        {
            this.Directory = directory; this.Profile = profile;
            if (fileIniDataParser is null) fileIniDataParser = new FileIniDataParser();
            this.Config = new Config(profile, this.Directory.CombineFile("instance.cfg"), fileIniDataParser);
            // Console.WriteLine(this.ToJson());
        }
    }

    public partial class MMCInstanceConfig
    {
        public IniData iniData = new IniData();
        public MMCInstanceConfig()
        {
            iniData.Global.AddKey("AutoCloseConsole", "true");
            iniData.Global.AddKey("ForgeVersion", "");
            iniData.Global.AddKey("InstanceType", "OneSix");
            iniData.Global.AddKey("IntendedVersion", "");
            iniData.Global.AddKey("JavaArchitecture", "64");
            iniData.Global.AddKey("JavaPath", "C:/Program Files/AdoptOpenJDK/jdk-15.0.2.7-hotspot/bin/javaw.exe");
            iniData.Global.AddKey("JavaTimestamp", "1611206204000");
            iniData.Global.AddKey("JavaVersion", "15.0.2");
            iniData.Global.AddKey("JvmArgs", "-XX:+UnlockExperimentalVMOptions");
            iniData.Global.AddKey("LWJGLVersion", "");
            iniData.Global.AddKey("LaunchMaximized", "false");
            iniData.Global.AddKey("LiteloaderVersion", "");
            iniData.Global.AddKey("LogPrePostOutput", "true");
            iniData.Global.AddKey("MCLaunchMethod", "LauncherPart");
            iniData.Global.AddKey("MaxMemAlloc", "4096");
            iniData.Global.AddKey("MinMemAlloc", "2048");
            iniData.Global.AddKey("MinecraftWinHeight", "480");
            iniData.Global.AddKey("MinecraftWinWidth", "854");
            iniData.Global.AddKey("OverrideCommands", "false");
            iniData.Global.AddKey("OverrideConsole", "false");
            iniData.Global.AddKey("OverrideJava", "false");
            iniData.Global.AddKey("OverrideJavaArgs", "true");
            iniData.Global.AddKey("OverrideJavaLocation", "true");
            iniData.Global.AddKey("OverrideMCLaunchMethod", "false");
            iniData.Global.AddKey("OverrideMemory", "true");
            iniData.Global.AddKey("OverrideNativeWorkarounds", "false");
            iniData.Global.AddKey("OverrideWindow", "false");
            iniData.Global.AddKey("PermGen", "128");
            iniData.Global.AddKey("PostExitCommand", "");
            iniData.Global.AddKey("PreLaunchCommand", "");
            iniData.Global.AddKey("ShowConsole", "false");
            iniData.Global.AddKey("ShowConsoleOnError", "true");
            iniData.Global.AddKey("UseNativeGLFW", "false");
            iniData.Global.AddKey("UseNativeOpenAL", "false");
            iniData.Global.AddKey("WrapperCommand", "");
            iniData.Global.AddKey("iconKey", "vivecraft");
            iniData.Global.AddKey("lastLaunchTime", "1614793595994");
            iniData.Global.AddKey("name", "");
            iniData.Global.AddKey("notes", "");
            iniData.Global.AddKey("totalTimePlayed", "0");
        }
    }

    public partial class Config
    {
        public FileInfo File;
        public IniData Data;
        internal FileIniDataParser FileIniDataParser;
        public Config(LauncherProfile profile, FileInfo file, FileIniDataParser fileIniDataParser = null)
        {
            this.FileIniDataParser = fileIniDataParser;
            this.File = file;
            if (this.File.Exists)
                this.Load();
        }
        public IniData Load()
        {
            this.Data = this.FileIniDataParser.ReadFile(this.File.FullName);
            return this.Data;
        }
        public bool Save(IniData data)
        {
            this.FileIniDataParser.WriteFile(this.File.FullName, data);
            return true;
        }
        public bool Save() => Save(this.Data);
    }
}


//public static string AutoCloseConsole { get; set; } = "true";
//public static string ForgeVersion { get; set; }
//public static string InstanceType { get; set; } = "OneSix";
//public static string IntendedVersion { get; set; }
//public static string JavaArchitecture { get; set; } = "64";
//public static string JavaPath { get; set; } = "C:/Program Files/AdoptOpenJDK/jdk-15.0.2.7-hotspot/bin/javaw.exe";
//public static string JavaTimestamp { get; set; } = "1611206204000";
//public static string JavaVersion { get; set; } = "15.0.2";
//public static string JvmArgs { get; set; } = "-XX:+UnlockExperimentalVMOptions";
//public static string LWJGLVersion { get; set; }
//public static string LaunchMaximized { get; set; } = "false";
//public static string LiteloaderVersion { get; set; }
//public static string LogPrePostOutput { get; set; } = "true";
//public static string MCLaunchMethod { get; set; } = "LauncherPart";
//public static string MaxMemAlloc { get; set; } = "512";
//public static string MinMemAlloc { get; set; } = "2048";
//public static string MinecraftWinHeight { get; set; } = "480";
//public static string MinecraftWinWidth { get; set; } = "854";
//public static string OverrideCommands { get; set; } = "false";
//public static string OverrideConsole { get; set; } = "false";
//public static string OverrideJava { get; set; } = "false";
//public static string OverrideJavaArgs { get; set; } = "true";
//public static string OverrideJavaLocation { get; set; } = "true";
//public static string OverrideMCLaunchMethod { get; set; } = "false";
//public static string OverrideMemory { get; set; } = "true";
//public static string OverrideNativeWorkarounds { get; set; } = "false";
//public static string OverrideWindow { get; set; } = "false";
//public static string PermGen { get; set; } = "128";
//public static string PostExitCommand { get; set; }
//public static string PreLaunchCommand { get; set; }
//public static string ShowConsole { get; set; } = "false";
//public static string ShowConsoleOnError { get; set; } = "true";
//public static string UseNativeGLFW { get; set; } = "false";
//public static string UseNativeOpenAL { get; set; } = "false";
//public static string WrapperCommand { get; set; }
//public static string iconKey { get; set; }
//public static string lastLaunchTime { get; set; } = "1614793595994";
//public static string name { get; set; }
//public static string notes { get; set; }
//public static string totalTimePlayed { get; set; } = "184";

//public static readonly Dictionary<string, string> defaultInstanceConfig = new Dictionary<string, string>
//{
//    { "AutoCloseConsole", "true" },
//    { "ForgeVersion", "" },
//    { "InstanceType", "OneSix" },
//    { "IntendedVersion", "" },
//    { "JavaArchitecture", "64" },
//    { "JavaPath", "C:/Program Files/AdoptOpenJDK/jdk-15.0.2.7-hotspot/bin/javaw.exe" },
//    { "JavaTimestamp", "1611206204000" },
//    { "JavaVersion", "15.0.2" },
//    { "JvmArgs", "-XX:+UnlockExperimentalVMOptions" },
//    { "LWJGLVersion", "" },
//    { "LaunchMaximized", "false" },
//    { "LiteloaderVersion", "" },
//    { "LogPrePostOutput", "true" },
//    { "MCLaunchMethod", "LauncherPart" },
//    { "MaxMemAlloc", "4096" },
//    { "MinMemAlloc", "2048" },
//    { "MinecraftWinHeight", "480" },
//    { "MinecraftWinWidth", "854" },
//    { "OverrideCommands", "false" },
//    { "OverrideConsole", "false" },
//    { "OverrideJava", "false" },
//    { "OverrideJavaArgs", "true" },
//    { "OverrideJavaLocation", "true" },
//    { "OverrideMCLaunchMethod", "false" },
//    { "OverrideMemory", "true" },
//    { "OverrideNativeWorkarounds", "false" },
//    { "OverrideWindow", "false" },
//    { "PermGen", "128" },
//    { "PostExitCommand", "" },
//    { "PreLaunchCommand", "" },
//    { "ShowConsole", "false" },
//    { "ShowConsoleOnError", "true" },
//    { "UseNativeGLFW", "false" },
//    { "UseNativeOpenAL", "false" },
//    { "WrapperCommand", "" },
//    { "iconKey", "vivecraft" },
//    { "lastLaunchTime", "1614793595994" },
//    { "name", "" },
//    { "notes", "" },
//    { "totalTimePlayed", "184" }
//};