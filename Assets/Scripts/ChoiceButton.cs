using UnityEngine;
using TMPro;

public class ChoiceButton : MonoBehaviour {
    public string next;
    public string option;
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private TMP_Text text;
    public void Start() {
        dialogueManager = FindObjectOfType<DialogueManager>();
        text.SetText(option);
    }

    public void OnClick() {
        dialogueManager.InitializeDialogue(next);
    }
}
