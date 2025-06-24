using UnityEngine;

// フルーツを画面上部から落とす役割のスクリプト
public class FruitSpawner : MonoBehaviour
{
    // インスペクターから設定するフルーツのプレハブ（＝複製する元になるオブジェクト）
    [SerializeField] private GameObject fruitPrefab;

    // フルーツを落とす位置（画面の上部などに空のオブジェクトを置いて設定する）
    [SerializeField] private Transform spawnPoint;

    void Update()
    {
        // スペースキーが押されたときに処理を実行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // fruitPrefab を spawnPoint の位置に生成する
            Instantiate(fruitPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
