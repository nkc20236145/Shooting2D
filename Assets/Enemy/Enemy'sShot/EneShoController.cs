using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneShoController : MonoBehaviour
{
    Transform player;   // プレイヤーのトランスフォームコンポーネントを保存
    float speed;        // 移動速度
    GameDirector gd;    // GameDirectorコンポーネント保存
    Vector3 dir;        // 移動方向

    void Start()
    {
        // プレイヤーの情報を保存
        this.player = GameObject.Find("Player").transform;

        // 弾の速度
        this.speed = 10f;

        // 弾の移動方向をプレイヤーのいる方向にする
        this.dir = player.position - transform.position;

        // GameDirectorコンポーネントを取得
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        transform.position += dir.normalized * speed * Time.deltaTime;

        // 4秒たったら破棄
        Destroy(gameObject,4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //衝突したオブジェクトがplayerだったとき
        if (collision.gameObject.CompareTag("player"))
        {
            // SE再生
            SeManager.Instance.Play("maou_se_magical29",0.5f,2.2f);
            // 距離を200km減らす
            gd.Kyori -= 200;
            Destroy(gameObject);
        }
    }
}
