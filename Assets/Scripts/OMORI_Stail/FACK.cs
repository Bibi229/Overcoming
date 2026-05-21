using UnityEngine;

public class FACK : MonoBehaviour
{
    [SerializeField] private Animator animator;
     
    public float speed = 5f;
    public Transform movePoint;
    
    public LayerMask whatStopsMovement;

    void Awake()
    {
        movePoint.parent = null;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .02f, whatStopsMovement))
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                
            }
        } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .02f, whatStopsMovement))
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                
            }
        }
        }
      

        if (animator != null)
        {
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

       

    }
}
