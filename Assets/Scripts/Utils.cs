using System.IO;
using System.Collections.Generic;
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