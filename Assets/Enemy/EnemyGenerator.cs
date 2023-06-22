using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPre;   // �G�̃v���n�u��ۑ�����ϐ�
    float delta;                  // �o�ߎ��Ԍv�Z�p
    float span;                   // �G���o������Ԋu

    void Start()
    {
        this.delta = 0;
        this.span = 1.0f;
    }

    void Update()
    {
        // �o�ߎ��Ԃ����Z
        delta += Time.deltaTime;

        // span�b���ɏ������s��
        if (delta > span)
        {
            // �G�𐶐�����
            GameObject go = Instantiate(EnemyPre);
            float py = Random.Range(-5.0f, 5.0f);
            go.transform.position = new Vector3(10, py, 0);

            //���Ԍo�߂�ۑ����Ă���ϐ����O�N���A����
            delta = 0;

            //�G���o���Ԋu�����X�ɒZ������
            span -= (span >= 0.5f) ? 0.01f : 0f;
        }
    }
}
