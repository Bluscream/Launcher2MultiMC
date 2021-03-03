namespace MCLauncher2MultiMC
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;


    public partial class MMCPack
    {
        public _Data Data;
        public MMCPack()
        {
        }
        public MMCPack fromProfile(LauncherProfile profile)
        {
            Data = new
            return this;
        }

        public partial class _Data
        {
        [JsonProperty("components", NullValueHandling = NullValueHandling.Ignore)]
        public List<Component> Components { get; set; }

        [JsonProperty("formatVersion", NullValueHandling = NullValueHandling.Ignore)]
        public long? FormatVersion { get; set; }
    }

    public partial class Component
    {
        [JsonProperty("cachedName", NullValueHandling = NullValueHandling.Ignore)]
        public string CachedName { get; set; }

        [JsonProperty("cachedVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string CachedVersion { get; set; }

        [JsonProperty("cachedVolatile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CachedVolatile { get; set; }

        [JsonProperty("dependencyOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DependencyOnly { get; set; }

        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("cachedRequires", NullValueHandling = NullValueHandling.Ignore)]
        public List<CachedRequire> CachedRequires { get; set; }

        [JsonProperty("important", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Important { get; set; }
    }

    public partial class CachedRequire
    {
        [JsonProperty("equals", NullValueHandling = NullValueHandling.Ignore)]
        public string CachedRequireEquals { get; set; }

        [JsonProperty("suggests", NullValueHandling = NullValueHandling.Ignore)]
        public string Suggests { get; set; }

        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; set; }
        }
    }
}
