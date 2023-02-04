using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;

public class SpeechVomiter : MonoBehaviour {
    public char[] currentSpeech;
    public Character currentCharacter;
    private List<Character> characters;
    private JsonReader jsonReader = new JsonReader();
    private TMP_Text NameBox, DialogueBox;
    private State state = State.WAITING;
    [SerializeField] private float timerDelay = 1f;
    private float triggerTimer = 0f;
    private int charIndex = 0;

    public void Awake() {
        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        NameBox = texts[0];
        DialogueBox = texts[1];

        string jsonString = jsonReader.Read(new string[] { "characters.json" });
        characters = JsonConvert.DeserializeObject<CharacterList>(jsonString).characters;
    }

    public void Update() {
        if (currentCharacter != null) NameBox.text = currentCharacter.GetName();

        if (state == State.READING) {
            if (charIndex == currentSpeech.Length) {
                state = State.WAITING;
            } else if (triggerTimer <= 0f) {
                DialogueBox.text = Vomit(currentSpeech[charIndex]);
            } else {
                triggerTimer -= 1 * Time.deltaTime;
            }
        }
    }

    // TODO: This can be improved
    public string Vomit(char text) {
        string vomit = charIndex > 0 ? DialogueBox.text : "";
        if (text.ToString() == "<") {
            while (true) {
                if (currentSpeech[charIndex].ToString() == ">") break;
                vomit += currentSpeech[charIndex];
                charIndex += 1;
            }
        } else {
            vomit += currentSpeech[charIndex];
            charIndex += 1;
            triggerTimer = timerDelay / 1000f;
        }

        return vomit;
    }

    public string CleanText(string text) {
        return text.Replace("/$", "</i>").Replace("$", "<i>").Replace("/*", "</b>").Replace("*", "<b>");
    }

    public void UpdateSpeech(string speech, string charId = null) {
        // Changing Characters
        currentCharacter = charId == null ? null : characters.Find(c => c.id == charId);

        // Changing speech
        currentSpeech = CleanText(speech).ToCharArray();

        // Reset all timers
        charIndex = 0;
        state = State.READING;
    }

    private enum State {
        WAITING,
        READING,
    }
}
