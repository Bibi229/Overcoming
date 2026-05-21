using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float speed;
    public Transform Point;
    private void Awake()
    {
        Point.parent = null;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Point.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, Point.position) <= 0.10f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            Point.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

        }
           if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            Point.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            
        }
        }
        
    }
}
