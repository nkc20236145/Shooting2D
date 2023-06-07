using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;   // 移動方向を保存する変数
    float speed = 5.0f;           // speedの値を保存
    Animator anim;                // アニメーターコンポーネントの情報を

    void Start()
    {
        //  アニメーターコンポーネントの情報を保存
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 移動方向をセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

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
