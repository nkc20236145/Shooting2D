using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPre;   // “G‚ÌƒvƒŒƒnƒu‚ð•Û‘¶‚·‚é•Ï”
    float delta;                  // Œo‰ßŽžŠÔŒvŽZ—p
    float span;                   // 

    void Start()
    {
        delta = 0;
        span = 1.2f;
    }

    void Update()
    {
        // Œo‰ßŽžŠÔ‚ð‰ÁŽZ
        delta += Time.deltaTime;
        if (delta > span)
        {
            // “G‚ð¶¬‚·‚é
            GameObject go = Instantiate(EnemyPre);
            float py = Random.Range(-5.0f, 5.0f);
            go.transform.position = new Vector3(10, py, 0);

            //ŽžŠÔŒo‰ß‚ð•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ð‚OƒNƒŠƒA‚·‚é
            delta = 0;

            //“G‚ðo‚·ŠÔŠu‚ð™X‚É’Z‚­‚·‚é
            span -= (span >= 0.8f) ? 0.03f : 0f;
        }
    }
}
