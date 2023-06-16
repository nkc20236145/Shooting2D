using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon_Ren : MonoBehaviour
{
    Vector3 dir = Vector3.zero;   // �ړ�������ۑ�����ϐ�
    float speed = 8.0f;           // speed�̒l��ۑ�

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
