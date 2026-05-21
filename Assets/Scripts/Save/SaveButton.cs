using UnityEngine;
using System.Collections;

public class SaveButton : MonoBehaviour
{
     public SaveManager saveManager;
    public GameObject saveText;

    private bool inside;

    void Start()
    {
        saveText.SetActive(false);
    }

    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.F))
        {
            saveManager.SaveGame();
            StartCoroutine(ShowText());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            inside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            inside = false;
    }

    IEnumerator ShowText()
    {
        saveText.SetActive(true);
        yield return new WaitForSeconds(1f);
        saveText.SetActive(false);
    }
}
