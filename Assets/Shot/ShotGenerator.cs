using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine;

public class ShotGenerator : MonoBehaviour
{
    public GameObject ShotPre;   // 弾のプレハブを保存する
    float timer;                 // 弾の発射間隔を調整
    int power;                   // 弾のレベル
    GameObject player;
    GameObject Kyori;


    // 弾のレベル値を他のスクリプトから
    // 参照・変更するためのプロパティ
    public int Power
    {
        set
        {
            power = value;
            power = Mathf.Clamp(power, 0, 12);
        }
        get { return power; }
    }

    void Start()
    {
        // 弾のプレハブを変数に保存する
        //ShotPre = (GameObject)Resources.Load("ShotPre");
        this.player = GameObject.Find("Player");
        this.Kyori = GameObject.Find("Kyori");
    }


    void Update()
    {
        // Cを押したら、弾のレベルが１上がる
        if (Input.GetKeyDown(KeyCode.C))
        {
            power = (power + 1) % 13;
            //Debug.Log("弾のレベルが上がったよ"); 動作確認
        }
        // 飛行距離が5000km到達したら、弾のレベルが２あがる
        if(this.Kyori.GetComponent<Text>().text == "005000km")
        {
            power = (power + 2) % 13;
        }

        // Zキーで弾発射
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && timer > 0.3f)
        {
            for (int i = -power; i < power + 1; i++)
            {
                // プレイヤーの現在地をposに保存
                Vector3 pos = this.player.transform.position + new Vector3(1, 0, 0);

                // プレイヤーの回転角度を取得
                Vector3 r = this.player.transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);
                Quaternion rot = Quaternion.Euler(r);

                // 弾を生成する際に、プレイヤーの位置と角度をセット
                Instantiate(ShotPre, pos, rot);
            }
            timer = 0;
        }
    }
}
