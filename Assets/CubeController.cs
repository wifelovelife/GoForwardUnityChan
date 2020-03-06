using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private float speed = -12f; // 移動速度
    private float deadline = -10f; // 消滅位置

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

    // ブロック衝突時に効果音を鳴らす
    void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log(tag);
        //Debug.Log(collision.gameObject.tag);

        string getTag = collision.gameObject.tag;
        if (getTag == "GroundTag" || getTag == "BlockTag") { // GroundとBlockに限定
            GetComponent<AudioSource>().Play();
        }

        //switch (tag) {
        //    case "GroundTag":
        //        GetComponent<AudioSource>().Play();
        //        break;
        //    case "BlockTag":
        //        GetComponent<AudioSource>().Play();
        //        break;
        //    case "UnityChanTag":
        //        GetComponent<AudioSource>().Stop();
        //        break;
        //}
    }
}
