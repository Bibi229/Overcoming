using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int _buildIndexSceneGame = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(_buildIndexSceneGame);
    }
    public void ExitGame()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
