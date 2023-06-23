using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;    // 移動方向を保存する変数
    float speed0;                  // speed0の値を保存
    float speed1;                  // speed1の値を保存
    Animator anim;                 // アニメーターコンポーネントの情報を保存

    // 自キャラのスピードの値を他のスクリプトから
    // 参照・変更するためのプロパティ
    public float Speed0
    {
        set
        {
            speed0 = value;
            speed0 = Mathf.Clamp(speed0,1,20);
        }
        get { return speed0; }
    }

    public float Speed1
    {
        set
        {
            speed1 = value;
            speed1 = Mathf.Clamp(speed1, 1, 20);
        }
        get { return speed1; }
    }
    void Start()
    {
        //  アニメーターコンポーネントの情報を保存
        anim = GetComponent<Animator>();
        speed0 = 10f;

        int[] playerType = { 0, 1 };    // プレイヤーの種類
    }

    void Update()
    {
        // 移動方向をセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed0 * Time.deltaTime;

        // 画面内移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        pos.y = Mathf.Clamp(pos.y, -4.75f, 4.75f);
        transform.position = pos;

        // アニメーション設定
        if(dir.y == 0)
        {
            // アニメーションクリップ[Player]を再生
            anim.Play("Player");
        }
        else if(dir.y == 1)
        {
            anim.Play("Player_L");
        }
        else if (dir.y == -1)
        {
            anim.Play("Player_R");
        }
    }
}
