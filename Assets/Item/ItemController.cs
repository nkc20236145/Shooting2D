using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    SpriteRenderer spRender;    // �����_���[�R���|�[�l���g���擾
    Vector3 pos;                // �o���ʒu
    Vector3 dir;                // �ړ�����
    float rad;
    int itemType;               // �A�C�e���̎��
    float speed;                // �������x

    void Start()
    {
        itemType = Random.Range(0, 3);  // �A�C�e���̎�ނO�`�Q
        speed = 5f;                     // �������x
        rad = Time.time;

        // itemType = 0:�� / itemType = 1:�� / itemType = 2:��
        Color[] col = { Color.red, Color.green, Color.blue, };
        spRender = GetComponent<SpriteRenderer>();
        spRender.color = col[itemType]; // �A�C�e���^�C�v�̔ԍ��ɍ��킹�ĐF����

        // �o���ʒu
        pos.x = Random.Range(-8f, 8f);
        pos.y = 6f;
        pos.z = 0;
        transform.position = pos;
        // �ړ�����
        dir = Vector3.down;

        // �����R�b
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // �������ɗh��Ȃ���ړ�
        this.dir.x = Mathf.Cos(rad + Time.time * 5.0f);
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    // �d�Ȃ蔻��
    void OnTriggerEnter2D(Collider2D c)
    {
        // �d�Ȃ�������̃^�O���yplayer�z��������
        if (c.gameObject.tag == "player")
        {
            // PlayerController�R���|�[�l���g��ۑ�
            PlayerController pCon = c.gameObject.GetComponent<PlayerController>();
            ShotGenerator sGen = c.gameObject.GetComponent<ShotGenerator>();

            // �A�C�e���̎�ޕʂɏ�����ύX
            if (itemType == 0)       // �ԁF�e���x���{�P
            {
                sGen.Power += 1;
            }
            else if (itemType == 1)  // �΁F�X�s�[�h�{�T
            {
                pCon.Speed0 += 5;
            }
            else if (itemType == 2)  // �F�e���x���O�@�X�s�[�h�T
            {
                pCon.Speed0 = 5;
                sGen.Power = 0;
            }

            // �����i�A�C�e���j�폜
            Destroy(gameObject);
        }
    }
}
