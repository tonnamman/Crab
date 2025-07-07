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

    public int scoreValue = 10;// ����Ѻ�����ٵ��

    public event Action OnDie;  // Event ������¡����� Enemy ���

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        // ���� Player
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
        if (collision.CompareTag("Weapon")) // ��Ҷ١���ظ����
        {
            Instantiate(_crabDead, transform.position, Quaternion.identity);
            Destroy(gameObject);

            GameManager.score += 10;
            Debug.Log(GameManager.score);
            OnDie?.Invoke();

            
           // ���¡ Event ������ѵ�ٵ��
        }

        if (collision.CompareTag("Player")) // ����ѵ�٪� Player
        {
            Player player = collision.GetComponent<Player>(); // �֧������ Player
            if (player != null)
            {
                player.Die(); // ���¡�ѧ��ѹ����� Player ���
            }
        }

    }
}
