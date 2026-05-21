using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Transform player;
    public ShopState state;

    public Vector3 savedPosition;
    public bool questStarted;
    public bool questDone;

    public void SaveGame()
    {
        savedPosition = player.position;

        questStarted = state.questStarted;
        questDone = state.questDone;

        PlayerPrefs.SetFloat("x", savedPosition.x);
        PlayerPrefs.SetFloat("y", savedPosition.y);
        PlayerPrefs.SetFloat("z", savedPosition.z);

        PlayerPrefs.SetInt("questStarted", questStarted ? 1 : 0);
        PlayerPrefs.SetInt("questDone", questDone ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("x")) return;

        Vector3 pos;
        pos.x = PlayerPrefs.GetFloat("x");
        pos.y = PlayerPrefs.GetFloat("y");
        pos.z = PlayerPrefs.GetFloat("z");

        player.position = pos;

        state.questStarted = PlayerPrefs.GetInt("questStarted") == 1;
        state.questDone = PlayerPrefs.GetInt("questDone") == 1;
    }
}
