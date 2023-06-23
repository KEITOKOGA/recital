using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]private GameObject createPrefab1;
    [SerializeField]private GameObject createPrefab2;
    [SerializeField]private Transform rangeA;
    [SerializeField]private Transform rangeB;
    [SerializeField]float e1_interval = 0;
    [SerializeField]float e2_interval = 0;

    // �o�ߎ���
    public float e1_time;
    public float e2_time;

    // Update is called once per frame
    void Update()
    {
        // �O�t���[������̎��Ԃ����Z���Ă���
        e1_time += Time.deltaTime;
        e2_time += Time.deltaTime;

        // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        if (e1_time > e1_interval)
        {
            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            Instantiate(createPrefab1, new Vector2(x, y), createPrefab1.transform.rotation);

            // �o�ߎ��ԃ��Z�b�g
            e1_time = 0f;
        }
        if (e2_time > e2_interval)
        {
            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            Instantiate(createPrefab2, new Vector2(x, y), createPrefab2.transform.rotation);

            // �o�ߎ��ԃ��Z�b�g
            e2_time = 0f;
        }
    }

}