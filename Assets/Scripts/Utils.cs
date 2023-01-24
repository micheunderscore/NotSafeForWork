using System.IO;
using UnityEngine;

public class JsonReader {
    public string Read(string route) {
        string filePath = Path.Combine(Application.streamingAssetsPath + Path.DirectorySeparatorChar, route);
        string jsonString = "";

#if UNITY_EDITOR || UNITY_IOS
        jsonString = File.ReadAllText(filePath);

#elif UNITY_ANDROID
        WWW reader = new WWW (filePath);
        while (!reader.isDone) {
        }
        jsonString = reader.text;
#endif

        return (jsonString);
    }
}