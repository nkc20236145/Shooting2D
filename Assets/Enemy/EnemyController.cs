using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject ShotPre;    // 弾のプレハブを保存
    Vector3 dir;                  // 移動方向
    float speed = 5.0f;           // 移動速度
    int enemyType;                // 敵の種類を保存
    float rad;                  // 敵の動きサインカーブ用
    float shotTime;               // 弾の発射間隔計算用
    float shotInterval = 2f;      // 弾の発射間隔
    GameDirector gd;              // GameDirectorコンポーネントを保存

    void Start()
    {  
        Destroy(gameObject, 6.0f);             // 寿命4秒
        this.enemyType = Random.Range(0, 3);   // 敵の種類
        this.dir = Vector3.left;               // 移動方向を決定
        this.rad = Time.time;                  // サインカーブの動きをずらす用
        this.shotTime = 0;                     // 弾の発射間隔計算用

        // GameObjectコンポーネントを保存
        this.gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update()
    {
        // enemyType2だけ規則的不規則移動
        if(enemyType == 2)
        {
            this.dir.y = Mathf.Sin(rad + Time.time * 5f);
        }

        // 現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        // 敵の弾の生成
        shotTime += Time.deltaTime;
        if(shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
        }
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
