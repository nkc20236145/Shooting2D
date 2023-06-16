using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;   // 移動方向
    float speed = 5.0f;           // 移動速度

    void Start()
    {
        // 寿命4秒
        Destroy(gameObject, 4.0f);
    }

    void Update()
    {
        // 移動方向を決定
        dir = Vector3.left;

        // 現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //衝突したオブジェクトがplayerだったとき
        if (collision.gameObject.CompareTag("player"))
        {
            // 制限時間を１０秒減らす
            GameDirector.lastTime -= 10f;
            Destroy(gameObject);
        }

        // 衝突したオブジェクトがshotだったとき
        if (collision.gameObject.CompareTag("Shot"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
