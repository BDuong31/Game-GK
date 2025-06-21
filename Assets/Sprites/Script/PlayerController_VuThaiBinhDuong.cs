// PlayerController_VuThaiBinhDuong.cs (Phiên bản: Di chuyển + Nhảy đơn giản)
using UnityEngine;

public class PlayerController_VuThaiBinhDuong : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Power-up Settings")]
    public Sprite smallSprite;
    public Sprite bigSprite; 
    private bool isBig = false;
    private CapsuleCollider2D playerCollider;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator_VuThaiBinhDuong;
    private float moveInput;
    private bool isFacingRight = true;

    public AudioClip jumpSound;
    public AudioClip growSound;
    public AudioClip shrinkSound;
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator_VuThaiBinhDuong = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        animator_VuThaiBinhDuong.SetFloat("speed", Mathf.Abs(moveInput));

        if (Input.GetButtonDown("Jump"))
        {
            Jump_VuThaiBinhDuong(); 
        }
    }

    void FixedUpdate()
    {
        Move_VuThaiBinhDuong();
    }

    private void Jump_VuThaiBinhDuong()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        audioSource.PlayOneShot(jumpSound);
    }

    private void Move_VuThaiBinhDuong()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0 && !isFacingRight)
        {
            Flip_VuThaiBinhDuong();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip_VuThaiBinhDuong();
        }
    }

    private void Flip_VuThaiBinhDuong()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_VuThaiBinhDuong"))
        {


            Debug.Log("Player collided with an enemy. Game Over!");

            FindObjectOfType<GameManager_VuThaiBinhDuong>().ShowGameOverMenu_VuThaiBinhDuong();

            gameObject.SetActive(false);
        }
    }
    
        public void Grow_VuThaiBinhDuong()
    {
        if (!isBig)
        {
            isBig = true;
            spriteRenderer.sprite = bigSprite;
            playerCollider.size = new Vector2(1f, 2f); 
        }
    }

    // Hàm để Mario nhỏ lại
    private void Shrink_VuThaiBinhDuong()
    {
        isBig = false;
        spriteRenderer.sprite = smallSprite;
        playerCollider.size = new Vector2(1f, 1f); 
    }
}