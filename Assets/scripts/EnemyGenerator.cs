using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemyList;    // 生成オブジェクト
    [SerializeField] Transform _spawn1;                 // 生成位置
    [SerializeField] Transform _spawn2;                // 生成位置
    float minX, maxX, minY, maxY;                   // 生成範囲

    int _time = 0;
    [SerializeField] int _Interval = 5;        // 生成する間隔

    void Start()
    {
        minX = Mathf.Min(_spawn1.position.x, _spawn2.position.x);
        maxX = Mathf.Max(_spawn1.position.x, _spawn2.position.x);
        minY = Mathf.Min(_spawn1.position.y, _spawn2.position.y);
        maxY = Mathf.Max(_spawn1.position.y, _spawn2.position.y);
    }

    void Update()
    {
        ++_time;

        if (_time > _Interval)
        {
            _time = 0;
            int index = Random.Range(0,_enemyList.Count);
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);

            Instantiate(_enemyList[index], new Vector3(posX, posY, 0), Quaternion.identity);
        }
        //if(_) { }
    }
}