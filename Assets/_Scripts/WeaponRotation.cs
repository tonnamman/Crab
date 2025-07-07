using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb2d;

    [SerializeField]
    private float _speed = 200f; // ความเร็วในการหมุน

    // Start is called before the first frame update
    void Start()
    {
        // ตรวจสอบหาก _rb2d ยังไม่ได้กำหนด
        if (_rb2d == null)
        {
            _rb2d = GetComponent<Rigidbody2D>(); // กำหนด _rb2d ถ้ายังไม่ถูกกำหนด
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // หมุนอาวุธโดยใช้ MoveRotation
        _rb2d.MoveRotation(_rb2d.rotation + _speed * Time.fixedDeltaTime);
    }
}