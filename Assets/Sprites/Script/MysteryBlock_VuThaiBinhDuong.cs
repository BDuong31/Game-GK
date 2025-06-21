// MysteryBlock_VuThaiBinhDuong.cs
using UnityEngine;

public class MysteryBlock_VuThaiBinhDuong : MonoBehaviour
{
    public GameObject itemToSpawn; // Prefab của Coin sẽ được sinh ra
    public Sprite emptyBlockSprite; // Hình ảnh của khối sau khi đã bị húc
    private bool hasBeenHit = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBeenHit && collision.gameObject.CompareTag("Player_VuThaiBinhDuong") && collision.contacts[0].normal.y > 0.5f)
        {
            hasBeenHit = true;

            GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;

            if (itemToSpawn != null)
            {
                Instantiate(itemToSpawn, transform.position + Vector3.up, Quaternion.identity);
            }
        }
    }
}