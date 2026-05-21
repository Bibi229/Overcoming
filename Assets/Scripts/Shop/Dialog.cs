using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    
    public ShopState state;
    public PlayerInventory inventory;

    public GameObject shopUI;
    public GameObject dialogueUI;

    public Text text;
    public FacePiDoor sellerFace;

    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;

    public string[] lines;
    

    private int index;

    void Start()
    {
        Debug.Log("DIALOG LOADED");
        dialogueUI.SetActive(false);

        continueButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
    void Update()
    {

    }

    public void StartDialogue()
    {
        if (lines == null || lines.Length == 0)
        return;

        dialogueUI.SetActive(true);

        continueButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);

        index = 0;

        sellerFace.SetVisible(true);
        sellerFace.Show();
        if (!state.questStarted)
        {
            index = 0;
            text.text = lines[index];
        }
        else if (!state.questDone)
        {
            ShowQuestion();
        }
        else
        {
            OpenShop();
        }
    }

    public void Next()
    {
        index++;

        if (index < lines.Length)
        {
            text.text = lines[index];
            sellerFace.NextFrame();
        }
        else
        {
            dialogueUI.SetActive(false);
            state.questStarted = true;
        }
    }

    public void ShowQuestion()
    {
        text.text = "ты принес нужную вещь?";

        continueButton.SetActive(false);
        yesButton.SetActive(true);
        noButton.SetActive(true);

        sellerFace.NextFrame();
    }

    public void AnswerYes()
    {
        if (inventory.HasItem("QuestItem"))
        {
            state.questDone = true;

            dialogueUI.SetActive(false);
            shopUI.SetActive(true);
            Invoke(nameof(OpenShop), 1f);
            
        }
        else
        {
            Kick("не ври.");
            noButton.SetActive(false);
            yesButton.SetActive(false);
        }
    }

    public void AnswerNo()
    {
        Kick("ну и вали отсюда.");
        noButton.SetActive(false);
        yesButton.SetActive(false);
    }

    void Kick(string msg)   
    {
        text.text = msg;

        yesButton.SetActive(false);
        noButton.SetActive(false);

        Invoke(nameof(CloseDialogue), 1f);
    }

    void CloseDialogue()
    {
        dialogueUI.SetActive(false);
        continueButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
  
    }
    void OpenShop()
    {
        dialogueUI.SetActive(false);
        shopUI.SetActive(true);

        continueButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
 
}
