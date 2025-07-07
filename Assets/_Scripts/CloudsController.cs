using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _clouds = new Transform[6];

    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private float _xLimit = 12.5f;

    // Start is called before the first frame update
    void Start()
    {
        // สามารถใช้สำหรับการตั้งค่าตำแหน่งเริ่มต้นของเมฆ
        foreach (var cloud in _clouds)
        {
            cloud.position = new Vector3(Random.Range(-_xLimit, -_xLimit / 2), cloud.position.y, cloud.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _clouds.Length; i++)
        {
            // เคลื่อนที่เมฆไปทางขวา
            _clouds[i].position += Vector3.right * Time.deltaTime * _speed;

            // ตรวจสอบว่าถึงขอบเขตหรือไม่
            if (_clouds[i].position.x > _xLimit)
            {
                // รีเซ็ตตำแหน่งเมฆกลับไปทางซ้าย
                _clouds[i].position = new Vector3(-_xLimit, _clouds[i].position.y, _clouds[i].position.z);
            }
        }
    }
}