using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10f;
        // �t���[�����ɓ����ňړ�������
        // �����Ă��������1�b�Ԃ�10m�i��
        transform.position += transform.up * speed * Time.deltaTime;
        // ��ʊO�ɏo����j��
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }

    }
}
