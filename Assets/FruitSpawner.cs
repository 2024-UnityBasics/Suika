using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // インスペクター上で、落とすフルーツのプレハブを複数登録する
    [SerializeField] private GameObject[] fruitPrefabs;

    // フルーツを生成する位置（移動できるスポーンポイント）
    [SerializeField] private Transform spawnPoint;

    // スポーンポイントの左右移動の速さ
    [SerializeField] private float moveSpeed = 5f;

    // スポーンポイントが動ける左右の範囲（画面外に出ないように）
    [SerializeField] private float xLimit = 2.5f;

    void Update()
    {
        // プレイヤーの左右入力（←→キー）を取得
        float input = Input.GetAxisRaw("Horizontal");

        // 現在のスポーンポイントの位置を取得して、X座標を更新
        Vector3 pos = spawnPoint.position;
        pos.x += input * moveSpeed * Time.deltaTime;

        // スポーンポイントが画面端を超えないように制限する
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);

        // 実際にスポーンポイントを新しい位置に反映
        spawnPoint.position = pos;

        // スペースキーが押されたらフルーツを1つ生成する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // fruitPrefabs配列からランダムに1つ選んで生成
            int index = Random.Range(0, fruitPrefabs.Length);

            // スポーンポイントの位置にフルーツを生成（回転なし）
            Instantiate(fruitPrefabs[index], spawnPoint.position, Quaternion.identity);
        }
    }
}
