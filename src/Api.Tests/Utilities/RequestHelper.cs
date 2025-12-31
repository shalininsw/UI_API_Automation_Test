using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api.Tests.Utilities
{
    public static class RequestHelper
    {
        public static T LoadDtoFromJson<T>(string relativePath) where T : class
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(baseDirectory, relativePath);
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string GetFullPath(string relativePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, relativePath);
        }
        public static Dictionary<string, string> ToFormDictionary<T>(T dto)
        {
            var j = JObject.FromObject(dto);
            return j.ToObject<Dictionary<string, string>>();
        }
    }
}
