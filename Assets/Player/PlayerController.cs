using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;   // 移動方向を保存する変数
    float speed = 5.0f;           // speedの値を保存

    void Start()
    {
        
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
    }
}
