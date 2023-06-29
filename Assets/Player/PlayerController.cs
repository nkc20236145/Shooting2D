using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;    // �ړ�������ۑ�����ϐ�
    Vector3 pos;
    float speed;                   // speed�̒l��ۑ�
    Animator anim;                 // �A�j���[�^�[�R���|�[�l���g�̏���ۑ�

    // ���L�����̃X�s�[�h�̒l�𑼂̃X�N���v�g����
    // �Q�ƁE�ύX���邽�߂̃v���p�e�B
    public float Speed
    {
        set
        {
            speed = value;
            speed = Mathf.Clamp(speed,1,20);
        }
        get { return speed; }
    }

    void Start()
    {
        //  �A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();
        speed = 10f;
    }

    void Update()
    {
        // �ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        
        transform.position += dir.normalized * speed * Time.deltaTime;

        // ��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        pos.y = Mathf.Clamp(pos.y, -4.75f, 4.75f);
        transform.position = pos;

        // �A�j���[�V�����ݒ�
        if(dir.y == 0)
        {
            // �A�j���[�V�����N���b�v[Player]���Đ�
            anim.Play("Player");
        }
        else if(dir.y == 1)
        {
            anim.Play("Player_L");
        }
        else if (dir.y == -1)
        {
            anim.Play("Player_R");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g��player�������Ƃ�
        if (collision.gameObject.CompareTag("SpeedEnemy"))
        {
            // �A�j���[�V�����ݒ�
            if (dir.y == 0)
            {
                // �A�j���[�V�����N���b�v[Player]���Đ�
                anim.Play("Player");
            }
            else if (dir.y == 1)
            {
                anim.Play("Player_R");
            }
            else if (dir.y == -1)
            {
                anim.Play("Player_L");
            }

            speed *= -1;
        }
    }
}
