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

    // ★次に落とすフルーツのインデックスを保存
    private int nextFruitIndex;

    // ★見本として表示するフルーツ（物理なし）
    private GameObject previewFruit;

    // ★ゲーム開始時に次のフルーツを準備
    void Start()
    {
        GenerateNextFruit();
    }

    void Update()
    {
        // 左右入力でスポーンポイントを移動
        float input = Input.GetAxisRaw("Horizontal");
        Vector3 pos = spawnPoint.position;
        pos.x += input * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        spawnPoint.position = pos;

        // スペースキーでフルーツをスポーン
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ★見本のフルーツと同じ種類を実体として生成
            Instantiate(fruitPrefabs[nextFruitIndex], spawnPoint.position, Quaternion.identity);

            // ★見本は一度削除して、新しく次の見本を生成
            if (previewFruit != null)
            {
                Destroy(previewFruit);
            }

            GenerateNextFruit(); // ★次のフルーツを準備
        }
    }

    // ★次に落とすフルーツの見本を生成する処理
    private void GenerateNextFruit()
    {
        // ★ランダムに次のインデックスを決める
        nextFruitIndex = Random.Range(0, fruitPrefabs.Length);

        // ★見本フルーツをスポーンポイントの子として生成（表示だけ）
        previewFruit = Instantiate(fruitPrefabs[nextFruitIndex], spawnPoint);

        // ★物理挙動と当たり判定をオフにする（見た目専用）
        Rigidbody2D rb = previewFruit.GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = false;

        Collider2D col = previewFruit.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // ★見本はスポーンポイントにピッタリ合わせる
        previewFruit.transform.localPosition = Vector3.zero;
        previewFruit.transform.localRotation = Quaternion.identity;
    }
}
