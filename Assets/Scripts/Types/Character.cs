using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class Character {
    public Name name;
    [JsonConverter(typeof(StringEnumConverter))]
    public Emotion emotion;
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