using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class Chapter {
    public string locale;
    public string chapter_id;
    public string other;
    public string head;
    public Dialogue[] dialogues;
}

[Serializable]
public class Dialogue {
    public string id;
    public Scene[] scenes;
    public Reply[] replies;
}

[Serializable]
public class Scene {
    public StageChange[] stage;
    public string character;
    public string[] speech;
    public string end;
}

[Serializable]
public class StageChange {
    public string target;
    [JsonProperty("emotion")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Emotion emotion { get; set; }
    [JsonProperty("transition")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Transition transition { get; set; }
    public string to;
    public bool flipped;

}

[Serializable]
public class Reply {
    public string option;
    public string next;
}

public enum Transition {
    jump,
    leave,
    fromTop,
    fromBottom,
    fromLeft,
    fromRight,
    toTop,
    toBottom,
    toLeft,
    toRight,
    fadeIn,
    fadeOut
}


