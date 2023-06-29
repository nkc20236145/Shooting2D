using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject ExploPre;     // �����̃v���n�u��ۑ�
    public GameObject ShotPre;      // �e�̃v���n�u��ۑ�
    Vector3 dir;                    // �ړ�����
    float speed = 5.0f;             // �ړ����x
    int enemyType;                  // �G�̎�ނ�ۑ�
    float rad;                      // �G�̓����T�C���J�[�u�p
    float shotTime;                 // �e�̔��ˊԊu�v�Z�p
    float shotInterval = 3.5f;        // �e�̔��ˊԊu
    GameDirector gd;                // GameDirector�R���|�[�l���g��ۑ�

    void Start()
    {  
        Destroy(gameObject, 6.0f);             // ����4�b
        this.enemyType = Random.Range(0, 3);   // �G�̎��
        this.dir = Vector3.left;               // �ړ�����������
        this.rad = Time.time;                  // �T�C���J�[�u�̓��������炷�p
        this.shotTime = 0;                     // �e�̔��ˊԊu�v�Z�p

        // GameObject�R���|�[�l���g��ۑ�
        this.gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update()
    {
        // enemyType2�����K���I�s�K���ړ�
        if(enemyType == 2)
        {
            this.dir.y = Mathf.Sin(rad + Time.time * 5f);
        }

        // ���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;

        // �G�̒e�̐���
        shotTime += Time.deltaTime;
        if(shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g��player�������Ƃ�
        if (collision.gameObject.CompareTag("player"))
        {
            // ���������炷
            gd.Kyori -= 1000;

            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(ExploPre, transform.position, transform.rotation);
            // SE�Đ�
            SeManager.Instance.Play("ban _maou_se_battle18",0.5f,1.0f);

            // �j��
            Destroy(gameObject);
        }

        // �Փ˂����I�u�W�F�N�g��shot�������Ƃ�
        if (collision.gameObject.CompareTag("Shot"))
        {
            // �����𑝂₷
            gd.Kyori += 200;

            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(ExploPre, transform.position, transform.rotation);
            // SE�Đ�            
            SeManager.Instance.Play("ban _maou_se_battle18",0.5f,1.0f);

            // ���݂��ɔj��
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
