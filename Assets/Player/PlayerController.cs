using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;    // �ړ�������ۑ�����ϐ�
    float speed0;                  // speed0�̒l��ۑ�
    float speed1;                  // speed1�̒l��ۑ�
    Animator anim;                 // �A�j���[�^�[�R���|�[�l���g�̏���ۑ�

    // ���L�����̃X�s�[�h�̒l�𑼂̃X�N���v�g����
    // �Q�ƁE�ύX���邽�߂̃v���p�e�B
    public float Speed0
    {
        set
        {
            speed0 = value;
            speed0 = Mathf.Clamp(speed0,1,20);
        }
        get { return speed0; }
    }

    public float Speed1
    {
        set
        {
            speed1 = value;
            speed1 = Mathf.Clamp(speed1, 1, 20);
        }
        get { return speed1; }
    }
    void Start()
    {
        //  �A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();
        speed0 = 10f;

        int[] playerType = { 0, 1 };    // �v���C���[�̎��
    }

    void Update()
    {
        // �ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed0 * Time.deltaTime;

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
}
