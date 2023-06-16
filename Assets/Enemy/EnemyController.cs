using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;   // �ړ�����
    float speed = 5.0f;           // �ړ����x

    void Start()
    {
        // ����4�b
        Destroy(gameObject, 4.0f);
    }

    void Update()
    {
        // �ړ�����������
        dir = Vector3.left;

        // ���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g��player�������Ƃ�
        if (collision.gameObject.CompareTag("player"))
        {
            // �������Ԃ��P�O�b���炷
            GameDirector.lastTime -= 10f;
            Destroy(gameObject);
        }

        // �Փ˂����I�u�W�F�N�g��shot�������Ƃ�
        if (collision.gameObject.CompareTag("Shot"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
