using UnityEngine;
using UnityEngine.UI;

public class FacePiDoor : MonoBehaviour
{
     public Image img;
    public Sprite[] frames;

    private int i;

    void Awake()
    {
        if (img == null)
            img = GetComponent<Image>();

        Hide();
    }

    public void Show()
    {
        if (img == null || frames == null || frames.Length == 0)
            return;

        i = 0;

        SetVisible(true);
        img.sprite = frames[i];
    }

    public void NextFrame()
    {
        if (img == null || frames == null || frames.Length == 0)
            return;

        i++;
        if (i >= frames.Length)
            i = 0;

        img.sprite = frames[i];

        SetVisible(true);
    }

    public void Hide()
    {
        SetVisible(false);
    }

    public void SetVisible(bool value)
    {
        if (img == null) return;

        Color c = img.color;
        c.a = value ? 1f : 0f;
        img.color = c;
    }
}
