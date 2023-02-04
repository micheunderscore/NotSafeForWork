
using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    [SerializeField] private Transform ChoiceBox;
    [SerializeField] private GameObject ChoiceButtonPrefab;
    private CharacterManager characterManager;
    private SpeechVomiter speechVomiter;
    private JsonReader jsonReader = new JsonReader();
    private Transformer t = new Transformer();
    private Chapter chapter;
    private Dialogue currentDialogue;
    private Queue<Dialogue> dialogues;
    private Queue<Scene> scenes;
    private Queue<string> speeches;
    private Reply[] currentReplies;
    private Scene currentScene;
    private State currentState;

    public void Awake() {
        characterManager = FindObjectOfType<CharacterManager>();
        speechVomiter = FindObjectOfType<SpeechVomiter>();
    }

    public void Start() {
        InitializeDialogue();
    }

    public void InitializeDialogue(string dialogueId = null) {
        string jsonString = jsonReader.Read(new string[] { "chapters", "00_example_chapter.json" });
        chapter = JsonConvert.DeserializeObject<Chapter>(jsonString);
        dialogues = t.ToDialogueQueue(chapter.dialogues);
        currentDialogue = Array.Find(chapter.dialogues, dialogue => dialogue.id == (dialogueId ?? chapter.head));
        scenes = t.ToSceneQueue(currentDialogue.scenes);

        currentState = State.SPEECH;
        DestroyChoices();

        NextDialogue();
    }

    public void Update() {
        switch (currentState) {
            case State.SPEECH:
                if (Input.GetMouseButtonDown(0)) {
                    NextDialogue();
                }
                break;
            case State.CHOICE:
                break;
        }

    }

    public void NextDialogue() {
        string currentSpeech = "", currentCharacter = null;
        while (true) {
            if (currentScene?.end != null) {
                currentSpeech = "End of Chapter";
                break;
            } else if (speeches != null && speeches.TryDequeue(out string dequeuedSpeech)) {
                currentSpeech = dequeuedSpeech;
                break;
            } else if (scenes.TryDequeue(out Scene dequeuedScene)) {
                currentScene = dequeuedScene;
                if (currentScene.character != null) currentCharacter = currentScene.character;
                if (currentScene.stage != null) characterManager.currentStage = currentScene.stage;
                if (currentScene.speech != null) speeches = t.ToStringQueue(currentScene.speech);
            } else {
                currentState = State.CHOICE;
                foreach (Reply reply in currentDialogue.replies) {
                    GameObject choiceButton = Instantiate(ChoiceButtonPrefab, parent: ChoiceBox);
                    choiceButton.GetComponent<ChoiceButton>().next = reply.next;
                    choiceButton.GetComponent<ChoiceButton>().option = reply.option;
                }
                break;
            }
        };
        speechVomiter.UpdateSpeech(currentSpeech, currentCharacter);
        characterManager.UpdateStage();
    }

    public void DestroyChoices() {
        foreach (GameObject choice in GameObject.FindGameObjectsWithTag("Choice")) Destroy(choice, 0.1f);
    }

    private enum State {
        SPEECH,
        CHOICE,
        CUTSCENE,
        END
    }
}
