using UnityEngine;

/// <summary>
/// �e�ۂ𐧌䂷��R���|�[�l���g
/// </summary>
public class EnemyUnderBullet : MonoBehaviour
{
    /// <summary>�e����ԑ���</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>�e�̐������ԁi�b�j</summary>
    [SerializeField] float m_lifeTime = 5f;

    void Start()
    {
        // ��������ɔ�΂�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1,-0.2f) * m_speed;
        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(this.gameObject, m_lifeTime);
    }
}