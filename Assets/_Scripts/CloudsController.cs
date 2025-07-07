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
        // ����ö������Ѻ��õ�駤�ҵ��˹�������鹢ͧ���
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
            // ����͹������价ҧ���
            _clouds[i].position += Vector3.right * Time.deltaTime * _speed;

            // ��Ǩ�ͺ��Ҷ֧�ͺࢵ�������
            if (_clouds[i].position.x > _xLimit)
            {
                // ���絵��˹������Ѻ价ҧ����
                _clouds[i].position = new Vector3(-_xLimit, _clouds[i].position.y, _clouds[i].position.z);
            }
        }
    }
}