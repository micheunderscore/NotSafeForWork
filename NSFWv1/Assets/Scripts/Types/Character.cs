using System;
using System.Collections.Generic;

public class CharacterList {
    public List<Character> characters;
}

public class Character {
    public string id;
    public int affection;
    public string soulmate;
    public Name name;

    public string GetName(string option = "first") {
        switch (option) {
            case "last":
                return name.last;
            case "middle":
                return name.middle;
            case "full":
                return name.first + (name.middle != null ? $" '{name.middle}' " : " ") + name.last;
            case "first":
            default:
                return name.first;
        }
    }
}

public class Name {
    public string first;
    public string middle;
    public string last;
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
    goofy,      // :P
    yay,        // ^o^
    horny       // XD
}