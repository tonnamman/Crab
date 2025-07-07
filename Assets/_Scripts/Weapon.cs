using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 200f; // ความเร็วในการหมุน

    // Start is called before the first frame update
    void Start()
    {
        // สามารถใช้สำหรับการตั้งค่าเริ่มต้น
    }

    // Update is called once per frame
    void Update()
    {
        // หมุนรอบตำแหน่งของตัวเอง
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}