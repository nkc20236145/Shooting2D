using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Ren : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //// X�����̈ړ�
        float speed = 5f;
        Vector3 dir = Vector3.left;

        // ���Ɍ��؂ꂽ��E����o��
        if (transform.position.x < -9f)
        {
            Vector3 pos = transform.position;
            pos.x = 9f;
            transform.position = pos;
        }

        // Y�����̈ړ�
        // -1 <= Mathf.Sin(Time.time * 5f) <= 1
        //dir.x = 5f * Mathf.Cos(Time.time * 5f);
        dir.y = 2f * Mathf.Sin(Time.time * 5f);
        Debug.Log(Time.time);

        //// �G�̈ړ��������v���C���[�̂�������ɂ���
        //dir = player.position - transform.position;


        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
