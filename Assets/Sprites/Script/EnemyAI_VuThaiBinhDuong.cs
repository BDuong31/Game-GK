// EnemyAI_VuThaiBinhDuong.cs
using UnityEngine;

public class EnemyAI_VuThaiBinhDuong : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 1.5f;

    public Transform groundDetection; 

    private bool movingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move_VuThaiBinhDuong();

        CheckForLedge_VuThaiBinhDuong();
    }

    private void Move_VuThaiBinhDuong()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void CheckForLedge_VuThaiBinhDuong()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundInfo.collider == false)
        {
            Flip_VuThaiBinhDuong();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle_VuThaiBinhDuong"))
        {
            Flip_VuThaiBinhDuong();
        }
    }

    private void Flip_VuThaiBinhDuong()
    {
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}