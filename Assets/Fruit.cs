using UnityEngine;

public class Fruit : MonoBehaviour
{
    // ���̃t���[�c�̃��x���i�������قǉ��ʁj
    [SerializeField] private int fruitLevel = 0;

    // ���̎��ɐ�������鎟�̃t���[�c�̃v���n�u
    [SerializeField] private GameObject nextFruitPrefab;

    // ���̍ς݃t���O�i���d�����h�~�j
    private bool isMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���肪Fruit�^�O�łȂ��Ȃ疳��
        if (!collision.gameObject.CompareTag("Fruit")) return;

        // �����Fruit�X�N���v�g���擾
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        // ���x���������łǂ���������̂Ȃ珈�����s
        if (otherFruit != null && otherFruit.fruitLevel == this.fruitLevel && !isMerged && !otherFruit.isMerged)
        {
            // ���̍ς݂ɐݒ�i�d���h�~�j
            isMerged = true;
            otherFruit.isMerged = true;

            // �����ʒu��2�̒���
            Vector3 spawnPosition = (this.transform.position + otherFruit.transform.position) / 2f;

            // ���̃t���[�c������Ȃ琶��
            if (nextFruitPrefab != null)
            {
                Instantiate(nextFruitPrefab, spawnPosition, Quaternion.identity);

                // ���̌��𗼕��폜���č��̊���
                Destroy(this.gameObject);
                Destroy(otherFruit.gameObject);
            }
        }
    }
}
