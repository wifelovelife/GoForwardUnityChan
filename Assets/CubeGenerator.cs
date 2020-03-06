using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject cubePrefab; // CubePrefabを読み込むための公開設定
    private float delta = 0; // 時間計測用の変数deltaを宣言
    private float span = 1.0f; // キューブの生成間隔：時間用
    private float genPosX = 12; // キューブの生成位置：x座標
    private float offsetY = 0.3f; // キューブの生成位置オフセット：y軸
    private float spaceY = 6.9f; // キューブの縦方向の間隔
    private float offsetX = 0.5f; // キューブの生成位置オフセット：x軸
    private float spaceX = 0.4f; // キューブの横方向の間隔
    private int maxBlockNum = 4; // キューブの生成個数の上限

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime; // 時間経過を変数deltaに代入
        if(this.delta > this.span) {
            this.delta = 0;
            int n = Random.Range(1, maxBlockNum + 1); // 生成するキューブの数をランダムに決定する
            for(int i = 0; i < n; i++) { // 指定した数だけキューブを生成する
                GameObject go = Instantiate(cubePrefab) as GameObject; // cubePrefabのインスタンスを生成して、変数goに代入する
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY); // 生成したキューブの位置
            }
            this.span = this.offsetX + this.spaceX * n; // 次のキューブが生成されるまでの時間を決定する
        }
	}
}
