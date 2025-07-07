using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    private Rigidbody2D _rb2d;
    private Transform _playerTransform;

    public bool Stopped = false;

    [SerializeField]
    private GameObject _crabDead;

    public int scoreValue = 10;// สำหรับทำให้ปูตาย

    public event Action OnDie;  // Event ให้เรียกเมื่อ Enemy ตาย

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        // ค้นหา Player
        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            Stopped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Stopped || _playerTransform == null)
        {
            _rb2d.velocity = Vector3.zero;
            return;
        }

        Vector3 directionToPlayer = _playerTransform.position - transform.position;
        _rb2d.velocity = directionToPlayer.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon")) // ถ้าถูกอาวุธโจมตี
        {
            Instantiate(_crabDead, transform.position, Quaternion.identity);
            Destroy(gameObject);

            GameManager.score += 10;
            Debug.Log(GameManager.score);
            OnDie?.Invoke();

            
           // เรียก Event เมื่อศัตรูตาย
        }

        if (collision.CompareTag("Player")) // ถ้าศัตรูชน Player
        {
            Player player = collision.GetComponent<Player>(); // ดึงข้อมูล Player
            if (player != null)
            {
                player.Die(); // เรียกฟังก์ชันทำให้ Player ตาย
            }
        }

    }
}
