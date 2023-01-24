
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    [SerializeField]
    private TMP_Text DialogueBox;
    [SerializeField]
    private Transform ChoiceBox;
    [SerializeField]
    private GameObject ChoiceButtonPrefab;
    private JsonReader jsonReader = new JsonReader();
    private Transformer t = new Transformer();
    private Chapter chapter;
    private Dialogue currentDialogue;
    private Queue<Dialogue> dialogues;
    private Queue<Scene> scenes;
    private Queue<string> speeches;
    private Reply[] currentReplies;
    private string currentSpeech;
    private Scene currentScene;
    private DialogueState currentState;

    public void Start() {
        InitializeDialogue();
    }

    public void InitializeDialogue(string dialogueId = null) {
        // FIXME: This currently doesn't support chapters where it starts with replies
        string jsonString = jsonReader.Read("chapters" + Path.DirectorySeparatorChar + "00_example_chapter.json");
        chapter = JsonUtility.FromJson<Chapter>(jsonString);

        dialogues = t.ToDialogueQueue(chapter.dialogues);

        currentDialogue = Array.Find(chapter.dialogues, dialogue => dialogue.id == (dialogueId ?? chapter.head));
        scenes = t.ToSceneQueue(currentDialogue.scenes);
        currentScene = scenes.Dequeue();

        speeches = t.ToStringQueue(currentScene.speech);
        currentSpeech = speeches.Dequeue();

        currentState = DialogueState.SPEECH;
        DestroyChoices();

        Debug.Log(JsonUtility.ToJson(chapter));
        Debug.Log(jsonString);
    }

    public void Update() {
        DialogueBox.SetText(currentSpeech);
        if (currentState != DialogueState.CHOICE) {
            if (Input.GetMouseButtonDown(0)) currentSpeech = NextDialogue();
        }
    }

    public string NextDialogue() {
        while (true) {
            if (currentScene.end != null) {
                return "End of Chapter";
            } else if (speeches.TryDequeue(out string dequeuedSpeech)) {
                return dequeuedSpeech;
            } else if (scenes.TryDequeue(out Scene dequeuedScene)) {
                currentScene = dequeuedScene;
                if (currentScene.speech != null) speeches = t.ToStringQueue(currentScene.speech);
            } else {
                currentState = DialogueState.CHOICE;
                foreach (Reply reply in currentDialogue.replies) {
                    GameObject choiceButton = Instantiate(ChoiceButtonPrefab, parent: ChoiceBox);
                    choiceButton.GetComponent<ChoiceButton>().next = reply.next;
                    choiceButton.GetComponent<ChoiceButton>().option = reply.option;
                }
                return "Answer the Question";
            }
        };
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
