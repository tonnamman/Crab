using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string _horizontalAxis = "Horizontal", _verticalAxis = "Vertical";

    [SerializeField]
    private Rigidbody2D _rb2d;

    [SerializeField]
    private float _moveSpeed = 5f; // ความเร็วของผู้เล่น

    private Vector2 _input;

    private int health = 3;  // พลังชีวิตเริ่มต้นที่ 3 หัวใจ

    public TMP_Text healthText; // แสดงพลังชีวิตใน UI

    public UnityEvent onPlayerDie; // Event ที่จะถูกเรียกเมื่อ Player ตาย

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // ตรวจสอบการเชื่อมต่อกับ UI
        if (healthText != null)
        {
            UpdateHealthUI();
        }
    }

    private void FixedUpdate()
    {
        // กำหนดความเร็วของ Rigidbody2D โดยคูณด้วยความเร็ว
        _rb2d.velocity = _input * _moveSpeed;
    }

    void Update()
    {
        // รับข้อมูลการควบคุมจากผู้ใช้งาน
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        float verticalInput = Input.GetAxisRaw(_verticalAxis);
        _input = new Vector2(horizontalInput, verticalInput).normalized; // ทำให้เวกเตอร์มีความยาว 1
    }

    // ฟังก์ชันที่เรียกเมื่อ Player ตาย
    public void Die()
    {
        // เรียก Event เพื่อให้ GameManager หรือ UI ทำงาน
        onPlayerDie?.Invoke();

        // หยุดเวลาเมื่อ Player ตาย
        Time.timeScale = 0f;  // หยุดเวลา

        // เรียกฟังก์ชัน GameOver ใน GameManager
        gameManager.GameOver();

        Destroy(gameObject);    // ทำลาย Player
    }

    // ลดพลังชีวิตเมื่อโดนปู
    public void TakeDamage()
    {
        health--; // ลดพลังชีวิต
        UpdateHealthUI();

        if (health <= 0)
        {
            Die();  // ถ้าพลังชีวิตเหลือน้อยกว่าหรือเท่ากับ 0 ให้ Player ตาย
        }
    }

    // อัพเดต UI เมื่อพลังชีวิตเปลี่ยนแปลง
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    // ตรวจจับการชนกับ Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่า Player ชนกับ Enemy หรือไม่
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();  // เรียกฟังก์ชัน TakeDamage เมื่อ Player ชนกับ Enemy
        }
    }
}
