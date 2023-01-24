
using System;
using System.Collections.Generic;
using System.Reflection;

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
    public Stage[] stage;
    public string character;
    public string[] speech;
    public string end;
}

[Serializable]
public class Stage {
    public string target;
    public Emotion emotion;
    public Transition transition;
    public To to;

}

public class Reply {
    public string option;
    public string next;
}

public enum Emotion {
    neutral,    // :|
    talk,       // :o
    happy,      // :D
    smile,      // :)
    surprise,   // O.O
    blush,      // >///<
    sad,        // :(
    crying,     // T.T
    angry,      // >:(
    bruh,       // :/
    goofy       // :P
}

public enum Transition {
    jump
}

public enum To {
    fromTop,
    fromBottom,
    fromLeft,
    fromRight,
    toTop,
    toBottom,
    toLeft,
    toRight,
    fade
};

