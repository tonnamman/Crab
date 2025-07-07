using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb2d;

    [SerializeField]
    private float _speed = 200f; // ��������㹡����ع

    // Start is called before the first frame update
    void Start()
    {
        // ��Ǩ�ͺ�ҡ _rb2d �ѧ������˹�
        if (_rb2d == null)
        {
            _rb2d = GetComponent<Rigidbody2D>(); // ��˹� _rb2d ����ѧ���١��˹�
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // ��ع���ظ���� MoveRotation
        _rb2d.MoveRotation(_rb2d.rotation + _speed * Time.fixedDeltaTime);
    }
}