using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;   // �ړ�����
    float speed = 6.0f;           // �ړ����x

    void Start()
    {
        // ����4�b
        Destroy(gameObject, 7.0f);
    }

    void Update()
    {
        // �ړ�����������
        dir = Vector3.left;

        // �K���I�s�K���ȓ���������
        dir.y = 2f * Mathf.Sin(Time.time * 5f);

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
