using UnityEngine;

// フルーツをランダムに落とすスクリプト
public class FruitSpawner : MonoBehaviour
{
    // 落とすフルーツの候補をインスペクターから複数指定する
    [SerializeField] private GameObject[] fruitPrefabs;

    // フルーツを落とす位置
    [SerializeField] private Transform spawnPoint;

    void Update()
    {
        // スペースキーが押されたらフルーツを落とす
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ランダムにインデックスを選ぶ（0〜配列の長さ-1）
            int index = Random.Range(0, fruitPrefabs.Length);

            // 対応するフルーツをスポーンポイントに生成
            Instantiate(fruitPrefabs[index], spawnPoint.position, Quaternion.identity);
        }
    }
}