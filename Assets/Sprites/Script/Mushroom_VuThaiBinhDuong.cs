// Mushroom_VuThaiBinhDuong.cs
using UnityEngine;

public class Mushroom_VuThaiBinhDuong : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_VuThaiBinhDuong"))
        {
            // PlayerController_VuThaiBinhDuong player = other.GetComponent<PlayerController_VuThaiBinhDuong>();
            // if (player != null)
            // {
            //     player.Grow_VuThaiBinhDuong();
            // }

            Destroy(gameObject);
        }
    }
}