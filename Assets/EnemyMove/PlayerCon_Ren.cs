using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon_Ren : MonoBehaviour
{
    Vector3 dir = Vector3.zero;   // 移動方向を保存する変数
    float speed = 8.0f;           // speedの値を保存

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 移動方向をセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
