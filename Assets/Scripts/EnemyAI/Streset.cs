using System.ComponentModel.Design;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Streset : MonoBehaviour
{
    public Sprite[] sp;
    private Image img;
    public float value = 1f;
    public float drainSpeed = 0.2f;
    public float viewDistance = 5f;
    public Transform target;
    public Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       img = GetComponent<UnityEngine.UI.Image>();
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
       float dist = Vector2.Distance(player.position, target.position);

        bool canBeSeen = false;

        SpriteRenderer targetSr = target.GetComponent<SpriteRenderer>();

        if (targetSr != null && targetSr.enabled)
        {
            canBeSeen = true;
        }

        if (dist <= viewDistance && canBeSeen)
        {
            value -= drainSpeed * Time.deltaTime; 
            UpdateSprite();
            if(value <= 0)
            {
                SceneManager.LoadScene("Deth");
            }
        }

    }

    void UpdateSprite()
    {
        int index = Mathf.FloorToInt(value * (sp.Length - 1));
        img.sprite = sp[index];
    }
}
