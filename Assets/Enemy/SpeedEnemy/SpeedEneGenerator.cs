using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEneGenerator : MonoBehaviour
{
    public GameObject SpeedEnePre;   // 敵のプレハブを保存する変数
    float delta;                  // 経過時間計算用
    float span;                   // 敵が出現する間隔

    void Start()
    {
        this.delta = 0;
        this.span = 4.0f;
    }

    void Update()
    {
        // 経過時間を加算
        delta += Time.deltaTime;

        // span秒毎に処理を行う
        if (delta > span)
        {
            // 敵を生成する
            GameObject go = Instantiate(SpeedEnePre);
            float py = Random.Range(-5.0f, 5.0f);
            go.transform.position = new Vector3(10, py, 0);

            //時間経過を保存している変数を０クリアする
            delta = 0;
        }
    }
}
