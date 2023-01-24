
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    [SerializeField]
    private TMP_Text DialogueBox;
    private JsonReader jsonReader = new JsonReader();
    private Chapter chapter;
    private string currDialogue;
    private Scene[] scenes;
    private Queue<string> dialogues;

    public void Start() {
        string jsonString = jsonReader.Read("chapters" + Path.DirectorySeparatorChar + "00_example_chapter.json");
        chapter = JsonUtility.FromJson<Chapter>(jsonString);
        scenes = Array.Find(chapter.dialogues, dialogue => dialogue.id == chapter.head).scenes;
        dialogues = new Queue<string>(scenes[0].speech);
        currDialogue = dialogues.Dequeue();
    }

    // TODO: Create method to hierarchically dequeue speeches depending on if current queue is empty.

    public void Update() {
        DialogueBox.SetText(currDialogue);
        if (Input.GetMouseButtonDown(0))
            currDialogue = dialogues.Dequeue();
    }
}
