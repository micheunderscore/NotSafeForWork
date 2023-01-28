
using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    [SerializeField]
    private TMP_Text NameText;
    [SerializeField]
    private TMP_Text DialogueBox;
    [SerializeField]
    private Transform ChoiceBox;
    [SerializeField]
    private GameObject ChoiceButtonPrefab;
    [SerializeField]
    private CharacterManager characterManager;
    private JsonReader jsonReader = new JsonReader();
    private Transformer t = new Transformer();
    private Chapter chapter;
    private Dialogue currentDialogue;
    private Queue<Dialogue> dialogues;
    private Queue<Scene> scenes;
    private Queue<string> speeches;
    private Reply[] currentReplies;
    private string currentSpeech;
    private string currentCharacter;
    private Scene currentScene;
    private DialogueState currentState;

    public void Start() {
        characterManager = FindObjectOfType<CharacterManager>();
        InitializeDialogue();
    }

    public void InitializeDialogue(string dialogueId = null) {
        // FIXME: This currently doesn't support chapters where it starts with replies
        string jsonString = jsonReader.Read(new string[] { "chapters", "00_example_chapter.json" });
        chapter = JsonConvert.DeserializeObject<Chapter>(jsonString);
        dialogues = t.ToDialogueQueue(chapter.dialogues);
        currentDialogue = Array.Find(chapter.dialogues, dialogue => dialogue.id == (dialogueId ?? chapter.head));
        scenes = t.ToSceneQueue(currentDialogue.scenes);

        currentState = DialogueState.SPEECH;
        DestroyChoices();

        NextDialogue();
        // Debug.Log(JsonConvert.SerializeObject(chapter.dialogues[0].scenes[0].stage[1]));
        // Debug.Log(jsonString);
    }

    public void Update() {
        DialogueBox.SetText(currentSpeech);
        NameText.SetText(currentCharacter);
        if (currentState != DialogueState.CHOICE) {
            if (Input.GetMouseButtonDown(0)) {
                NextDialogue();
            }
        }
    }

    public void NextDialogue() {
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
                // FIXME: Check for if is at the end of a dialogue
                currentState = DialogueState.CHOICE;
                foreach (Reply reply in currentDialogue.replies) {
                    GameObject choiceButton = Instantiate(ChoiceButtonPrefab, parent: ChoiceBox);
                    choiceButton.GetComponent<ChoiceButton>().next = reply.next;
                    choiceButton.GetComponent<ChoiceButton>().option = reply.option;
                }
                currentSpeech = "Answer the Question";
                break;
            }
        };
        characterManager.UpdateStage();
    }

    public void DestroyChoices() {
        foreach (GameObject choice in GameObject.FindGameObjectsWithTag("Choice")) Destroy(choice, 0.1f);
    }

    private enum DialogueState {
        SPEECH,
        CHOICE,
        CUTSCENE,
        END
    }
}
