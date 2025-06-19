using UnityEngine;

public class WaypointPatrol : MonoBehaviour
{
    [Header("Waypoints")]
    [SerializeField] private Transform pointA; 
    [SerializeField] private Transform pointB; 

    [Header("Settings")]
    [SerializeField] private float speed = 2f; 

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Vui lòng gán cả hai điểm PointA và PointB!", this);
            this.enabled = false;
            return;
        }

        
        transform.position = pointA.position;
        
        currentTarget = pointB;
        FlipSprite();
    }

    void Update()
    {
        if (currentTarget == null) return;

        
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

       
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
        {
           
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }

            
            FlipSprite();
        }
    }

   
    private void FlipSprite()
    {
        if (transform.position.x < currentTarget.position.x)
        {
           
            spriteRenderer.flipX = false;
        }
        else
        {
            
            spriteRenderer.flipX = true;
        }
    }
}