using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoItemGenerator : MonoBehaviour{
    
    //carPerfabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject cornPrefab;
    //unityちゃんを入れる
    public GameObject unitychan;
    //スタート地点
    private int startPos = -160;
    //アイテム生成用のスタート地点
    private float startPos1 = -160f;
    //ゴール地点
    private int GoalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //unityちゃんの移動距離
    private float difference;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        // スタート地点から50m以内に一定の距離ごとにアイテムを生成
        for (int i = startPos; i < -115; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン設置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        difference = Mathf.Abs(startPos1 - unitychan.transform.position.z);
        // Unityちゃんが15m進むごとにアイテムを生成
        if(difference >= 15 && unitychan.transform.position.z >= -160 && unitychan.transform.position.z + 45 < GoalPos)
        {
            startPos1 = unitychan.transform.position.z;
            difference =Mathf.Abs(startPos1 - unitychan.transform.position.z);

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + 45);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン設置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + 45 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + 45 + offsetZ);
                    }
                }
            }
        }
    }
}