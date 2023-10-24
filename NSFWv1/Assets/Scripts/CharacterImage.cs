using UnityEngine;
using UnityEngine.UI;

public class CharacterImage : MonoBehaviour {
    private Image image;
    private Color visible = new Color(255, 255, 255, 1), transparent = new Color(255, 255, 255, 0);
    void Awake() {
        image = GetComponent<Image>();
    }

    void Update() {
        image.color = (image.sprite == null) ? transparent : visible;
    }
}
