using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 200f; // ��������㹡����ع

    // Start is called before the first frame update
    void Start()
    {
        // ����ö������Ѻ��õ�駤���������
    }

    // Update is called once per frame
    void Update()
    {
        // ��ع�ͺ���˹觢ͧ����ͧ
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}