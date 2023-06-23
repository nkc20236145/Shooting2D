using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEneController : MonoBehaviour
{
    PlayerController pCon;          // PlayerControllerコンポーネントを保存
    public GameObject ExploPre;     // 爆発のプレハブを保存
    float speed;                    // 移動速度
    Vector3 dir;                    // 移動方向

    void Start()
    {
        // 向いている方向に1秒間に15m進む
        this.speed = 15f;
        this.dir = Vector3.left;
        // GameObjectコンポーネントを保存
        this.pCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        // 画面外に出たら破棄
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //衝突したオブジェクトがplayerだったとき
        if (collision.gameObject.CompareTag("player"))
        {
            
           // 重なった相手が衝突爆発を生成
            Instantiate(ExploPre, transform.position, transform.rotation);

            // 破棄
            Destroy(gameObject);
        }

        // 衝突したオブジェクトがshotだったとき
        if (collision.gameObject.CompareTag("Shot"))
        {
            // 重なった相手が衝突爆発を生成
            Instantiate(ExploPre, transform.position, transform.rotation);

            // お互いに破棄
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
