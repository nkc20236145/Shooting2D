using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneShoController : MonoBehaviour
{
    Transform player;

    void Start()
    {
        this.player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // X軸の方向
        float speed = 5f;
        Vector3 dir = Vector3.left;

        // 敵の移動方向をプレイヤーのいる方向にする
        dir = player.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;

        // 画面外に出たら破棄
        if (transform.position.x > -10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //衝突したオブジェクトがplayerだったとき
        if (collision.gameObject.CompareTag("player"))
        {
            // 制限時間を5秒減らす
            GameDirector.lastTime -= 5f;
            Destroy(gameObject);
        }
    }
}
