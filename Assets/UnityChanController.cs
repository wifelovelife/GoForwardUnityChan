using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
    Animator animator; // アニメーションを扱うためのコンポーネントを取得する変数animatorを宣言
    Rigidbody2D rigid2D; // 移動を扱うためのコンポーネントを取得する変数rigid2Dを宣言
    private float groundLevel = -3.0f; // 地面の位置
    private float dump = 0.8f; // ジャンプの速度減退
    float jumpVelocity = 20; // ジャンプの速度
    private float deadLine = -9; // ゲームオーバーになる位置


    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>(); // アニメータのコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>(); // RigidBody2Dのコンポーネントを取得
	}
	

	// Update is called once per frame
	void Update () {
        this.animator.SetFloat("Horizontal", 1); // 走るアニメーションを再生するため、Animatorを調整

        bool isGround = (transform.position.y > this.groundLevel) ? false : true; // 着地しているかどうか調べる
        this.animator.SetBool("isGround", isGround);

        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0; // ジャンプ状態の時にボリュームを0にする

        if (Input.GetMouseButtonDown(0) && isGround) { // 着地状態でクリックされた場合
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity); // 上方向の力を加える
        }

        if(Input.GetMouseButton(0) == false) { // クリックをやめたら上方向への速度を減速する
            if(this.rigid2D.velocity.y > 0) {
                this.rigid2D.velocity *= this.dump;
            }
        }

        if(transform.position.x < this.deadLine) { // デッドラインを超えた場合
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver(); // Canvasオブジェクトの実体を検索し、UICOntrollerに実装されたGameOver関数を呼び出す
            Destroy(gameObject);
        }
	}
}
