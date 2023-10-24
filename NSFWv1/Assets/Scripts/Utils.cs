using System.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class EnumExtension {
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
       => self.Select((item, index) => (item, index));
}

public static class Common {
    public static string GetStreamingAssetsPath(string route) {
        return Path.Combine(Application.streamingAssetsPath, route);
    }

    public static string GetFullName(Character character) {
        return character.name.first + " " + character.name.last;
    }
}

public class JsonReader {
    public string Read(string[] routes) {
        string filePath = Common.GetStreamingAssetsPath(Path.Combine(routes));
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

public class ImageLoader {
    public Sprite Load(string[] routes, bool flipped = false) {
        byte[] pngBytes = System.IO.File.ReadAllBytes(Path.Combine(routes));
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
        return Sprite.Create(tex, new Rect(0.0f, 0.0f, flipped ? -tex.width : tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}

public class Transformer {
    public Queue<string> ToStringQueue(IEnumerable<string> arr) {
        Queue<string> queue = new Queue<string>(arr);
        return queue;
    }

    public Queue<Scene> ToSceneQueue(IEnumerable<Scene> arr) {
        Queue<Scene> queue = new Queue<Scene>(arr);
        return queue;
    }

    public Queue<Dialogue> ToDialogueQueue(IEnumerable<Dialogue> arr) {
        Queue<Dialogue> queue = new Queue<Dialogue>(arr);
        return queue;
    }

    public Queue<Reply> ToReplyQueue(IEnumerable<Reply> arr) {
        Queue<Reply> queue = new Queue<Reply>(arr);
        return queue;
    }
}