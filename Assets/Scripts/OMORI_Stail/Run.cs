using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Tilemaps;
public class Run : MonoBehaviour
{
    private Animator animator;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.4f;
    private Rigidbody2D rb;
    private bool isMoving; 
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }
  
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            timeToMove = 0.2f;
        }
        else
        {
            timeToMove = 0.4f;
        }

        if(Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if(Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        if(Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if(Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }

        //Animation
        if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
        //Right
        if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
            
        }
        else
        {
            animator.SetBool("Right", false);
        }
        //Back
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Back", true);
        }
        else
        {
            animator.SetBool("Back", false);
        }
        //Face
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Face", true);
        }
        else
        {
            animator.SetBool("Face", false);
        }


    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float speed = Input.GetKey(KeyCode.LeftShift) ? 5f : 3f;
        rb.linearVelocity = direction * speed;
        

        yield return new WaitForSeconds(timeToMove);

        rb.linearVelocity = Vector2.zero;
        isMoving = false;
    }
    
}