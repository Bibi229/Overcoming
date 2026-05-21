using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Xp : MonoBehaviour
{
    public Sprite[] hpSprites;
    private Image img;
    public float hp = 1f;

    public Transform target;
    public Transform player;
    void Awake()
    {
        img = GetComponent<UnityEngine.UI.Image>();
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }
     public void TakeDamage(float damage)
    {
        hp -= damage;
        hp = Mathf.Clamp01(hp);

        UpdateSprite();

        if(hp <= 0)
        {
            Die();
        }
    }

    void UpdateSprite()
    {
        if (hpSprites == null || hpSprites.Length == 0) return;
        int index = Mathf.FloorToInt(hp * (hpSprites.Length - 1));
        index = Mathf.Clamp(index, 0, hpSprites.Length - 1);
        img.sprite = hpSprites[index];
    }

    void Die()
    {
        Debug.Log("сдохла");
    }
}
