using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneShoController : MonoBehaviour
{
    Transform player;

    void Start()
    {
        this.player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // X���̕���
        float speed = 5f;
        Vector3 dir = Vector3.left;

        // �G�̈ړ��������v���C���[�̂�������ɂ���
        dir = player.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;

        // ��ʊO�ɏo����j��
        if (transform.position.x > -10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g��player�������Ƃ�
        if (collision.gameObject.CompareTag("player"))
        {
            // �������Ԃ�5�b���炷
            GameDirector.lastTime -= 5f;
            Destroy(gameObject);
        }
    }
}
