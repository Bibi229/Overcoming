using System.Collections;
using NUnit.Framework;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float visionRange = 5f;
    
    public float moveTime = 0.3f;
    public LayerMask obstacleLayer;
    public Transform player;
    private Animator anim;

    private bool isMoving;

    void Start()
    {
        // выравниваем по сетке
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            0
        );

        StartCoroutine(AI());

        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(isMoving == true)
        {
            anim.SetBool("Sleem", true);
        }
        else
        {
            anim.SetBool("Sleem", false);
        }
    }

    IEnumerator AI()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (!isMoving)
            {
                float dist = Vector3.Distance(transform.position, player.position);

                if (dist <= visionRange)
                {
                    Vector3 dir = GetDirectionToPlayer();
                    TryMove(dir);
                }
            }
        }
    }

    void TryMove(Vector3 direction)
    {
        Vector3 targetPos = transform.position + direction;

        // проверка на стену
        if (!Physics2D.OverlapCircle(targetPos, 0.2f, obstacleLayer))
        {
            StartCoroutine(Move(targetPos));
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        float elapsed = 0;

        while (elapsed < moveTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / moveTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    Vector3 GetDirectionToPlayer()
    {
        Vector3 diff = player.position - transform.position;

        // выбираем главное направление
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
            return diff.x > 0 ? Vector3.right : Vector3.left;
        else
            return diff.y > 0 ? Vector3.up : Vector3.down;
    }
}
