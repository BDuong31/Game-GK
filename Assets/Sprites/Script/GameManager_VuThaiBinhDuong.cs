// GameManager_VuThaiBinhDuong.cs
using UnityEngine;
using UnityEngine.SceneManagement; // Thư viện để quản lý Scene
using TMPro;

public class GameManager_VuThaiBinhDuong : MonoBehaviour
{
    public GameObject gameOverPanel; // Tham chiếu tới menu UI
    public TextMeshProUGUI scoreText; // Tham chiếu tới UI Text hiển thị điểm
    private AudioSource audioSource;
    private int score = 0;

    public AudioClip coinSound;
    public AudioClip gameOverSound;
    void Start()
    {
        UpdateScoreUI_VuThaiBinhDuong();
        audioSource = GetComponent<AudioSource>();

    }

    public void AddScore_VuThaiBinhDuong()
    {
        int lastDigitOfStudentID = 2;
        int pointsPerCoin = 1 + lastDigitOfStudentID; //

        score += pointsPerCoin;
        UpdateScoreUI_VuThaiBinhDuong();
        // audioSource.PlayOneShot(coinSound);
    }

    void UpdateScoreUI_VuThaiBinhDuong()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ShowGameOverMenu_VuThaiBinhDuong()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ReloadScene_VuThaiBinhDuong()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame_VuThaiBinhDuong()
    {
        Debug.Log("Exiting game..."); 

        Application.Quit();
    }
}