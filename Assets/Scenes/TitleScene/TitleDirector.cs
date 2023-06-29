using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    public Text scoreLabel; // 前回のスコア(距離)表示

    void Start()
    {
        // 距離表示
        scoreLabel.text = "Score\n" + GameDirector.kyori.ToString("D6");

        // BGMマネージャーを使ったBGM再生
        BgmManager.Instance.Play("maou_bgm_piano02");
    }

    void Update()
    {
        // 左クリックまたはゲームパッドのボタン０でスタート
        if(Input.GetButtonDown("Fire1"))
        {
            BgmManager.Instance.Stop();

            // SE再生
            SeManager.Instance.Play("maou_se_system29");

            // Fadeマネージャーを使ったフェード(秒数指定)
            FadeManager.Instance.LoadScene("GameScene", 2.0f);
        }
    }
}
