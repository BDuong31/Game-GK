// Coin_VuThaiBinhDuong.cs
using UnityEngine;

public class Coin_VuThaiBinhDuong : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_VuThaiBinhDuong"))
        {
            Debug.Log("Ăn xu thành công!"); 
            FindObjectOfType<GameManager_VuThaiBinhDuong>().AddScore_VuThaiBinhDuong();

            Destroy(gameObject);
        }
    }
}