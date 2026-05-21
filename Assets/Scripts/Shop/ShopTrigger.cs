using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public Dialog dialog;

    bool inside;

    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E))
        {
            dialog.StartDialogue();
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
}    
