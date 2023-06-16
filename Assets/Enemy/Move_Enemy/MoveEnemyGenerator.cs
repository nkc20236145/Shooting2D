using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyGenerator : MonoBehaviour
{
    public GameObject MoveEnemyPre;   // �G�̃v���n�u��ۑ�����ϐ�
    float delta;                  // �o�ߎ��Ԍv�Z�p
    float span;                   // 

    void Start()
    {
        delta = 0;
        span = 2.4f;
    }

    void Update()
    {
        // �o�ߎ��Ԃ����Z
        delta += Time.deltaTime;
        if (delta > span)
        {
            // �G�𐶐�����
            GameObject go = Instantiate(MoveEnemyPre);
            float py = Random.Range(-4.0f, 4.0f);
            go.transform.position = new Vector3(10, py, 0);

            //���Ԍo�߂�ۑ����Ă���ϐ����O�N���A����
            delta = 0;

            //�G���o���Ԋu�����X�ɒZ������
            span -= (span >= 1.8f) ? 0.03f : 0f;
        }
    }
}
