using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false; // ตัวแปรเก็บสถานะเกมโอเวอร์

    public static GameManager Instance; // ทำให้เป็น Singleton

    public TMP_Text healthText; // สำหรับแสดงพลังชีวิต

    public static int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // กำหนดตัวเองเป็น Instance
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
     

    }



   public void GameOver()
    {
        isGameOver = true; // ตั้งค่าเป็น Game Over
        Time.timeScale = 0f; // หยุดเวลา
        Debug.Log("Game Over! กด Enter เพื่อเริ่มใหม่");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // รีเซ็ตเวลาให้เดินต่อ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // โหลดฉากใหม่
    }

    private void Update()
    {
        // เช็กว่ากด Enter ได้เฉพาะตอน Game Over
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }
}
