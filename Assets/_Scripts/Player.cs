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
    private float _moveSpeed = 5f; // �������Ǣͧ������

    private Vector2 _input;

    private int health = 3;  // ��ѧ���Ե������鹷�� 3 ����

    public TMP_Text healthText; // �ʴ���ѧ���Ե� UI

    public UnityEvent onPlayerDie; // Event ���ж١���¡����� Player ���

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // ��Ǩ�ͺ����������͡Ѻ UI
        if (healthText != null)
        {
            UpdateHealthUI();
        }
    }

    private void FixedUpdate()
    {
        // ��˹��������Ǣͧ Rigidbody2D �¤ٳ���¤�������
        _rb2d.velocity = _input * _moveSpeed;
    }

    void Update()
    {
        // �Ѻ�����š�äǺ����ҡ�����ҹ
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        float verticalInput = Input.GetAxisRaw(_verticalAxis);
        _input = new Vector2(horizontalInput, verticalInput).normalized; // ������ǡ�����դ������ 1
    }

    // �ѧ��ѹ������¡����� Player ���
    public void Die()
    {
        // ���¡ Event ������� GameManager ���� UI �ӧҹ
        onPlayerDie?.Invoke();

        // ��ش��������� Player ���
        Time.timeScale = 0f;  // ��ش����

        // ���¡�ѧ��ѹ GameOver � GameManager
        gameManager.GameOver();

        Destroy(gameObject);    // ����� Player
    }

    // Ŵ��ѧ���Ե�����ⴹ��
    public void TakeDamage()
    {
        health--; // Ŵ��ѧ���Ե
        UpdateHealthUI();

        if (health <= 0)
        {
            Die();  // ��Ҿ�ѧ���Ե����͹��¡���������ҡѺ 0 ��� Player ���
        }
    }

    // �Ѿവ UI ����;�ѧ���Ե����¹�ŧ
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    // ��Ǩ�Ѻ��ê��Ѻ Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ǩ�ͺ��� Player ���Ѻ Enemy �������
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();  // ���¡�ѧ��ѹ TakeDamage ����� Player ���Ѻ Enemy
        }
    }
}
