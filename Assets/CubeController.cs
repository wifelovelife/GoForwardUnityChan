using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private float speed = -12f; // 移動速度
    private float deadline = -10f; // 消滅位置
    private bool blockHit = false; // ブロックの衝突判定

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(this.speed * Time.deltaTime, 0, 0); // キューブを移動させる

        if (transform.position.x < this.deadline) { // 画面外にでたら削除する
            Destroy(gameObject);
        }
    }

    // ブロック衝突時に変数blockCollisionに論理値trueを渡す
    void OnCollisionEnter2D(Collision2D collision) {
        this.blockHit = true;

        if (tag == "GroundTag" || tag == "BlockTag") { // 効果音をGroundTagとBlockTagに限定
            GetComponent<AudioSource>().Play();
        }
    }
}
