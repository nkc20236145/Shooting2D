using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;         // ������\������UI-Text�I�u�W�F�N�g
    public Text shotLabel;          // �e�̋�����\������UI-Text�I�u�W�F�N�g
    public Image timeGauge;         // �^�C���Q�[�W��\������

    public GameObject itemPre;      //  �A�C�e���v���n�u��ۑ�

    // �V���b�g�W�F�l���[�^�[�R���|�[�l���g���擾
    ShotGenerator sGen;

    public static float lastTime;   // �c�莞�Ԃ�ۑ�����ϐ�
    public static int kyori;        // �����v�Z�p

    // �����̒l�𑼂̃X�N���v�g����ύX���邽�߂̃v���p�e�B
    public int Kyori
    {
        set
        {
            kyori = value;
            kyori = Mathf.Clamp(kyori, 0, 999999);
        }
        get { return kyori; }
    }

    void Start()
    {
        kyori = 0;
        lastTime = 60.0f;          // �c�莞��60�b
        sGen = GameObject.Find("Player").GetComponent<ShotGenerator>();
    }

    void Update()
    {
        // �i�񂾋�����\��
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";

        // ������600km�Ŋ���؂��Ƃ��ɃA�C�e���o��
        if (kyori % 500 == 0)
        {
            Instantiate(itemPre);
        }

        // �v���[���[�̒e���x�����擾���ĕ\��
        shotLabel.text = "ShotLevel " + sGen.Power.ToString("D2");


        // �c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 60.0f;

        // �c�莞�Ԃ��O�ɂȂ����烊���[�h
        if(lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
