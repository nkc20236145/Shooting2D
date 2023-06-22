using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneShoController : MonoBehaviour
{
    Transform player;   // �v���C���[�̃g�����X�t�H�[���R���|�[�l���g��ۑ�
    float speed;        // �ړ����x
    GameDirector gd;    // GameDirector�R���|�[�l���g�ۑ�
    Vector3 dir;        // �ړ�����

    void Start()
    {
        // �v���C���[�̏���ۑ�
        this.player = GameObject.Find("Player").transform;

        // �e�̑��x
        this.speed = 5f;

        // �e�̈ړ��������v���C���[�̂�������ɂ���
        this.dir = player.position - transform.position;

        // GameDirector�R���|�[�l���g���擾
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ�����
        transform.position += dir.normalized * speed * Time.deltaTime;

        // ��ʊO�ɏo����j��
        if (transform.position.x < -10.0f )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g��player�������Ƃ�
        if (collision.gameObject.CompareTag("player"))
        {
            // ������200km���炷
            gd.Kyori -= 200;
            Destroy(gameObject);
        }
    }
}
