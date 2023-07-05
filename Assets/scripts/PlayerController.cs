using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _shipspeed_h = 5f; //自機の水平方向の速度
    [SerializeField] float _shipspeed_v = 5f; //自機の垂直方向の速度
    [SerializeField] float _highspeed = 2; //shiftを押した際の加速度
    Rigidbody2D m_rb = default;
    float m_h;
    float m_v;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        m_h = Input.GetAxisRaw("Horizontal");
        m_v = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * _shipspeed_h, ForceMode2D.Force);
        m_rb.AddForce(Vector2.up * m_v * _shipspeed_v, ForceMode2D.Force);
        if (Input.GetButton("Fire3"))
        {
            Debug.Log("HIGHSPEED MODE!!!");
            Time.timeScale = 1f * _highspeed;
        }
        else if (!Input.GetButton("Fire3"))
        {
            Time.timeScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemybullet")
        {
            SceneManager.LoadScene("GameoverScene");
        }
    }
}
