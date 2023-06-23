using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]private GameObject createPrefab1;
    [SerializeField]private GameObject createPrefab2;
    [SerializeField]private Transform rangeA;
    [SerializeField]private Transform rangeB;
    [SerializeField]float e1_interval = 0;
    [SerializeField]float e2_interval = 0;

    // 経過時間
    public float e1_time;
    public float e2_time;

    // Update is called once per frame
    void Update()
    {
        // 前フレームからの時間を加算していく
        e1_time += Time.deltaTime;
        e2_time += Time.deltaTime;

        // 約1秒置きにランダムに生成されるようにする。
        if (e1_time > e1_interval)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(createPrefab1, new Vector2(x, y), createPrefab1.transform.rotation);

            // 経過時間リセット
            e1_time = 0f;
        }
        if (e2_time > e2_interval)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(createPrefab2, new Vector2(x, y), createPrefab2.transform.rotation);

            // 経過時間リセット
            e2_time = 0f;
        }
    }

}