using UnityEngine;

public class Fruit : MonoBehaviour
{
    // このフルーツのレベル（小さいほど下位）
    [SerializeField] private int fruitLevel = 0;

    // 合体時に生成される次のフルーツのプレハブ
    [SerializeField] private GameObject nextFruitPrefab;

    // 合体済みフラグ（多重処理防止）
    private bool isMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 相手がFruitタグでないなら無視
        if (!collision.gameObject.CompareTag("Fruit")) return;

        // 相手のFruitスクリプトを取得
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        // レベルが同じでどちらも未合体なら処理実行
        if (otherFruit != null && otherFruit.fruitLevel == this.fruitLevel && !isMerged && !otherFruit.isMerged)
        {
            // 合体済みに設定（重複防止）
            isMerged = true;
            otherFruit.isMerged = true;

            // 生成位置は2つの中間
            Vector3 spawnPosition = (this.transform.position + otherFruit.transform.position) / 2f;

            // 次のフルーツがあるなら生成
            if (nextFruitPrefab != null)
            {
                Instantiate(nextFruitPrefab, spawnPosition, Quaternion.identity);

                // 合体元を両方削除して合体完了
                Destroy(this.gameObject);
                Destroy(otherFruit.gameObject);
            }
        }
    }
}
