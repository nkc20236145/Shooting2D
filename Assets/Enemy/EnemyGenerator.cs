using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPre;   // 敵のプレハブを保存する変数
    float delta;                  // 経過時間計算用
    float span;                   // 

    void Start()
    {
        delta = 0;
        span = 1.2f;
    }

    void Update()
    {
        // 経過時間を加算
        delta += Time.deltaTime;
        if (delta > span)
        {
            // 敵を生成する
            GameObject go = Instantiate(EnemyPre);
            float py = Random.Range(-5.0f, 5.0f);
            go.transform.position = new Vector3(10, py, 0);

            //時間経過を保存している変数を０クリアする
            delta = 0;

            //敵を出す間隔を徐々に短くする
            span -= (span >= 0.8f) ? 0.03f : 0f;
        }
    }
}
