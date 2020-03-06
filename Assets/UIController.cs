using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private GameObject gameOverText; // GameOverオブジェクトを取得する変数を宣言
    private GameObject runLengthText; // RunLengthオブジェクトを取得する変数を宣言
    private float len = 0; // 走った距離
    private float speed = 0.03f; // 走る速度
    private bool isGameOver = false; // ゲームオーバーの判定


	// Use this for initialization
	void Start () {
        this.gameOverText = GameObject.Find("GameOver"); // シーンからGameOverの実体を検索
        this.runLengthText = GameObject.Find("RunLength"); // シーンからRunLengthの実態を検索
	}
	
	// Update is called once per frame
	void Update () {
		if(this.isGameOver == false) {
            this.len += this.speed; // 走った距離を更新
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m"; // 走った距離を表示
        }

        if(this.isGameOver == true) { // ゲームオーバーになった場合
            if (Input.GetMouseButtonDown(0)) { // クリックされたらシーンをロードする
                SceneManager.LoadScene("GameScene"); // GameSceneを読み込む
            }
        }
	}

    public void GameOver() { // ゲームオーバー時、画面にGameOverを表示
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
