using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPointType // ประกาศ enum สำหรับประเภทจุดเกิด
{
    Topleft,
    TopRight,
    BottomLeft,
    BottomRight
}

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private int _enemyCount = 5;
    [SerializeField]
    private Transform _spawnTopLeft, _spawnTopRight, _spawnBottomLeft,
        _spawnBottomRight;

    private void Start()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = SelectRandomPosition();
        GameObject enemyObject = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.OnDie += SpawnEnemy;
        }


    }

    private Vector3 SelectRandomPosition()
    {
        Transform selectedTransform = null;
        int randomValue = Random.Range(0, 4);
        SpawnPointType spawnType = (SpawnPointType)randomValue;

        switch (spawnType)
        {
            case SpawnPointType.Topleft:
                {
                    selectedTransform = _spawnTopLeft;
                    break;
                }
            case SpawnPointType.TopRight:
                {
                    selectedTransform = _spawnTopRight;
                    break;
                }
            case SpawnPointType.BottomRight:
                {
                    selectedTransform = _spawnBottomRight;
                    break;
                }
            default:
                {
                    selectedTransform = _spawnBottomLeft;
                    break;
                }
        }

        return selectedTransform.position + (Vector3)Random.insideUnitCircle;
    }

    void Update()
    {
    }
}