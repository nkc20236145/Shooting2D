using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneShoGenerator : MonoBehaviour
{
    public GameObject EneShoPre;
    GameObject enemy;

    float span;
    float delta;

    void Start()
    {
        this.enemy = GameObject.Find("EnemyGenarator");
        delta = 0;
        span = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            GameObject go = Instantiate(EneShoPre);

            // Enemy‚©‚ç’e‚ªoŒ»‚·‚é
            Vector3 enemyPos = this.enemy.transform.position;
            go.transform.position = new Vector3(enemyPos.x, enemyPos.y, transform.position.z);

            delta = 0;
        }
    }
}
