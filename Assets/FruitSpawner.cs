using UnityEngine;

// �t���[�c����ʏ㕔���痎�Ƃ������̃X�N���v�g
public class FruitSpawner : MonoBehaviour
{
    // �C���X�y�N�^�[����ݒ肷��t���[�c�̃v���n�u�i���������錳�ɂȂ�I�u�W�F�N�g�j
    [SerializeField] private GameObject fruitPrefab;

    // �t���[�c�𗎂Ƃ��ʒu�i��ʂ̏㕔�Ȃǂɋ�̃I�u�W�F�N�g��u���Đݒ肷��j
    [SerializeField] private Transform spawnPoint;

    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ�Ƃ��ɏ��������s
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // fruitPrefab �� spawnPoint �̈ʒu�ɐ�������
            Instantiate(fruitPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
