using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    SpriteRenderer spRender;    // レンダラーコンポーネントを取得
    Vector3 pos;                // 出現位置
    Vector3 dir;                // 移動方向
    float rad;
    int itemType;               // アイテムの種類
    float speed;                // 落下速度

    void Start()
    {
        itemType = Random.Range(0, 3);  // アイテムの種類０～２
        speed = 5f;                     // 落下速度
        rad = Time.time;

        // itemType = 0:赤 / itemType = 1:緑 / itemType = 2:青
        Color[] col = { Color.red, Color.green, Color.blue, };
        spRender = GetComponent<SpriteRenderer>();
        spRender.color = col[itemType]; // アイテムタイプの番号に合わせて色がつく

        // 出現位置
        pos.x = Random.Range(-8f, 8f);
        pos.y = 6f;
        pos.z = 0;
        transform.position = pos;
        // 移動方向
        dir = Vector3.down;

        // 寿命３秒
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // 下方向に揺れながら移動
        this.dir.x = Mathf.Cos(rad + Time.time * 5.0f);
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    // 重なり判定
    void OnTriggerEnter2D(Collider2D c)
    {
        // 重なった相手のタグが【player】だったら
        if (c.gameObject.tag == "player")
        {
            // PlayerControllerコンポーネントを保存
            PlayerController pCon = c.gameObject.GetComponent<PlayerController>();
            ShotGenerator sGen = c.gameObject.GetComponent<ShotGenerator>();

            // アイテムの種類別に処理を変更
            if (itemType == 0)       // 赤：弾レベル＋１
            {
                sGen.Power += 1;
            }
            else if (itemType == 1)  // 緑：スピード＋５
            {
                pCon.Speed0 += 5;
            }
            else if (itemType == 2)  // 青：弾レベル０　スピード５
            {
                pCon.Speed0 = 5;
                sGen.Power = 0;
            }

            // 自分（アイテム）削除
            Destroy(gameObject);
        }
    }
}
