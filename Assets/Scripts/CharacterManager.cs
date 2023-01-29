using System;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class CharacterManager : MonoBehaviour {
    public List<StageChange> characters = new List<StageChange>();
    public StageChange[] currentStage;
    public Image[] slots = new Image[3];
    private ImageLoader imgLdr = new ImageLoader();
    public void Awake() {
        Image[] images = GetComponentsInChildren<Image>();

        foreach (var (image, i) in images.WithIndex()) {
            slots[i] = image;
        }

        ClearStage();
    }

    public void UpdateStage() {
        // FIXME: Refactor this to make more sense
        if (currentStage != null) {
            foreach (StageChange change in currentStage) {
                // Debug.Log(JsonConvert.SerializeObject(change));
                switch (change.target) {
                    case "bg":
                        // Debug.Log("Background change to " + change.to);
                        break;
                    case "player":
                        // Debug.Log("Player change to " + change.emotion);
                        break;
                    case "dialogue":
                        // Debug.Log("Dialogue transition: " + change.transition);
                        break;
                    default:
                        StageChange found = characters.Find((item) => item.target == change.target);
                        if (found != null) {
                            found.emotion = change.emotion;
                            found.transition = change.transition;
                            found.flipped = change.flipped;
                        } else {
                            characters.Insert(characters.Count, change);
                        }
                        break;
                }
            }
        }

        currentStage = null;

        if (characters.Count != 0 && slots.Length != 0)
            foreach (var (character, i) in characters.WithIndex()) {
                Debug.Log("Slot#" + i + ": " + JsonConvert.SerializeObject(character));
                slots[i].sprite = imgLdr.Load(new string[] { "Assets", "Media", "characters", character.target, character.emotion + ".png" }, character.flipped);
            }
    }

    public void ClearStage() {
        foreach (Image slot in slots) {
            slot.sprite = null;
        }
    }

}