using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEneController : MonoBehaviour
{
    PlayerController pCon;          // PlayerController�R���|�[�l���g��ۑ�
    public GameObject ExploPre;     // �����̃v���n�u��ۑ�
    float speed;                    // �ړ����x
    Vector3 dir;                    // �ړ�����

    void Start()
    {
        // �����Ă��������1�b�Ԃ�15m�i��
        this.speed = 15f;
        this.dir = Vector3.left;
        // GameObject�R���|�[�l���g��ۑ�
        this.pCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        // ��ʊO�ɏo����j��
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g��player�������Ƃ�
        if (collision.gameObject.CompareTag("player"))
        {
            
           // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(ExploPre, transform.position, transform.rotation);

            // �j��
            Destroy(gameObject);
        }

        // �Փ˂����I�u�W�F�N�g��shot�������Ƃ�
        if (collision.gameObject.CompareTag("Shot"))
        {
            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(ExploPre, transform.position, transform.rotation);

            // ���݂��ɔj��
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
