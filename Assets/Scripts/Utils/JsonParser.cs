using System.IO;
using UnityEngine;

namespace Utils
{
    public static class JsonParser
    {
        public static T Parse<T>(string jsonString)
        {
            return JsonUtility.FromJson<T>(jsonString);
        }

        public static T ReadAndParse<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return Parse<T>(jsonString);
        }
    }
}
