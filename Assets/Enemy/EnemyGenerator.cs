using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPre;   // �G�̃v���n�u��ۑ�����ϐ�
    float delta;                  // �o�ߎ��Ԍv�Z�p
    float span;                   // 

    void Start()
    {
        delta = 0;
        span = 1.2f;
    }

    void Update()
    {
        // �o�ߎ��Ԃ����Z
        delta += Time.deltaTime;
        if (delta > span)
        {
            // �G�𐶐�����
            GameObject go = Instantiate(EnemyPre);
            float py = Random.Range(-5.0f, 5.0f);
            go.transform.position = new Vector3(10, py, 0);

            //���Ԍo�߂�ۑ����Ă���ϐ����O�N���A����
            delta = 0;

            //�G���o���Ԋu�����X�ɒZ������
            span -= (span >= 0.8f) ? 0.03f : 0f;
        }
    }
}
