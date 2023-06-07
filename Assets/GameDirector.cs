using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;   // ������\������UI-Text�I�u�W�F�N�g
    int kyori;                // ������ۑ�����ϐ�

    public Image timeGauge;   // �^�C���Q�[�W��\������

    float lastTime;           // �c�莞�Ԃ�ۑ�����ϐ�
    
    void Start()
    {
        kyori = 0;
        lastTime = 5.0f;  // �c�莞��5�b
    }

    void Update()
    {
        // �c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100.0f;

        // �c�莞�Ԃ��O�ɂȂ����烊���[�h
        if(lastTime < 0)
        {
            SceneManager.LoadScene("GameScene");
        }

        // �i�񂾋�����\��
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";
    }
}
