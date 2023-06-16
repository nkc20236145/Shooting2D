using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine;

public class ShotGenerator : MonoBehaviour
{
    public GameObject ShotPre;   // �e�̃v���n�u��ۑ�����
    float timer;            // �e�̔��ˊԊu�𒲐�
    int power = 0;          // �e�̃��x��
    GameObject player;
    GameObject Kyori;

    void Start()
    {
        // �e�̃v���n�u��ϐ��ɕۑ�����
        //ShotPre = (GameObject)Resources.Load("ShotPre");
        this.player = GameObject.Find("Player");
        this.Kyori = GameObject.Find("Kyori");
    }


    void Update()
    {
        // C����������A�e�̃��x�����P�オ��
        if (Input.GetKeyDown(KeyCode.C))
        {
            power = (power + 1) % 13;
            //Debug.Log("�e�̃��x�����オ������"); ����m�F
        }
        // ��s������5000km���B������A�e�̃��x�����Q������
        if(this.Kyori.GetComponent<Text>().text == "005000km")
        {
            power = (power + 2) % 13;
        }

        // Z�L�[�Œe����
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && timer > 0.3f)
        {
            for (int i = -power; i < power + 1; i++)
            {
                // �v���C���[�̌��ݒn��pos�ɕۑ�
                Vector3 pos = this.player.transform.position + new Vector3(1, 0, 0);

                // �v���C���[�̉�]�p�x���擾
                Vector3 r = this.player.transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);
                Quaternion rot = Quaternion.Euler(r);

                // �e�𐶐�����ۂɁA�v���C���[�̈ʒu�Ɗp�x���Z�b�g
                Instantiate(ShotPre, pos, rot);
            }
            timer = 0;
        }
    }
}