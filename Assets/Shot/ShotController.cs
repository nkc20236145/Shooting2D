using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10f;
        // フレーム毎に等速で移動させる
        // 向いている方向に1秒間に10m進む
        transform.position += transform.up * speed * Time.deltaTime;
        // 画面外に出たら破棄
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }

    }
}
