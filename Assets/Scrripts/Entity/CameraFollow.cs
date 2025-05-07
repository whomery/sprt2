using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CameraFollow2D : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

      
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            target = player.transform;

         
            Collider2D playerCol = player.GetComponent<Collider2D>();
            Collider2D cameraCol = GetComponent<Collider2D>();
            if (playerCol != null && cameraCol != null)
            {
                Physics2D.IgnoreCollision(cameraCol, playerCol);
            }
        }
        else
        {
            Debug.LogError("Player 오브젝트를 찾을 수 없습니다.");
        }
    }

    void FixedUpdate()
    {
        if (target == null) return;

     
        Vector2 targetPos = new Vector2(target.position.x, target.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, moveSpeed * Time.fixedDeltaTime);

       
        rb.MovePosition(newPos);
    }

    void LateUpdate()
    {
       
        Vector3 current = transform.position;
        transform.position = new Vector3(current.x, current.y, offset.z);
    }
}