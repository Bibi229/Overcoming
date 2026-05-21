using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class BadWords : MonoBehaviour
{
    private SpriteRenderer sp;
    public Transform player;
    public float viewDistance = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        StartCoroutine(Word());
        sp.enabled = false;
    }

    void Update()
    {

    }
    IEnumerator Word() 
    {
        while(transform.parent != null)
        {
            float dist = Vector2.Distance(transform.position, player.position);

            if(dist <= viewDistance)
            {
                yield return new WaitForSeconds(5f);
                sp.enabled = true;
                yield return new WaitForSeconds(4f);
                sp.enabled = false;
            }
            yield return null;
            
        }
    }
}
