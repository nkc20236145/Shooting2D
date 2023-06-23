using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;         // 距離を表示するUI-Textオブジェクト
    public Text shotLabel;          // 弾の強さを表示するUI-Textオブジェクト
    public Image timeGauge;         // タイムゲージを表示する

    public GameObject itemPre;      //  アイテムプレハブを保存

    // ショットジェネレーターコンポーネントを取得
    ShotGenerator sGen;

    public static float lastTime;   // 残り時間を保存する変数
    public static int kyori;        // 距離計算用

    // 距離の値を他のスクリプトから変更するためのプロパティ
    public int Kyori
    {
        set
        {
            kyori = value;
            kyori = Mathf.Clamp(kyori, 0, 999999);
        }
        get { return kyori; }
    }

    void Start()
    {
        kyori = 0;
        lastTime = 60.0f;          // 残り時間60秒
        sGen = GameObject.Find("Player").GetComponent<ShotGenerator>();
    }

    void Update()
    {
        // 進んだ距離を表示
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";

        // 距離が600kmで割り切れるときにアイテム出現
        if (kyori % 500 == 0)
        {
            Instantiate(itemPre);
        }

        // プレーヤーの弾レベルを取得して表示
        shotLabel.text = "ShotLevel " + sGen.Power.ToString("D2");


        // 残り時間を減らす処理
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 60.0f;

        // 残り時間が０になったらリロード
        if(lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
