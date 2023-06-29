using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    public Text scoreLabel; // �O��̃X�R�A(����)�\��

    void Start()
    {
        // �����\��
        scoreLabel.text = "Score\n" + GameDirector.kyori.ToString("D6");

        // BGM�}�l�[�W���[���g����BGM�Đ�
        BgmManager.Instance.Play("maou_bgm_piano02");
    }

    void Update()
    {
        // ���N���b�N�܂��̓Q�[���p�b�h�̃{�^���O�ŃX�^�[�g
        if(Input.GetButtonDown("Fire1"))
        {
            BgmManager.Instance.Stop();

            // SE�Đ�
            SeManager.Instance.Play("maou_se_system29");

            // Fade�}�l�[�W���[���g�����t�F�[�h(�b���w��)
            FadeManager.Instance.LoadScene("GameScene", 2.0f);
        }
    }
}
