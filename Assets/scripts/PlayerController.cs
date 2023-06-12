using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float _shipspeed_h = 5f; //自機の水平方向の速度
    [SerializeField]float _shipspeed_v = 5f; //自機の垂直方向の速度
    [SerializeField]float _highspeed = 2; //shiftを押した際の加速度
    [SerializeField] Transform m_muzzle = default; //銃口の位置
    [SerializeField] GameObject m_bullet1 = default; //弾1
    [SerializeField] GameObject m_bullet2 = default; //弾2
    [SerializeField] float b1_interval = 0.5f;
    [SerializeField] float b2_interval = 10f;
    Rigidbody2D m_rb = default;
    float m_h;
    float m_v;
    float b1_timer;
    float b2_timer;
    void Start()
    {
        b1_timer = b1_interval;
        b2_timer = b2_interval;
        m_rb = GetComponent<Rigidbody2D>();
        //m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        b1_timer += Time.deltaTime;
        b2_timer += Time.deltaTime;
        m_h = Input.GetAxisRaw("Horizontal");
        m_v = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Fire1") && b1_timer > b1_interval)
        {
            b1_timer = 0;
            GameObject bullet = Instantiate(m_bullet1);
            bullet.transform.position = m_muzzle.transform.position;
            //m_audio.Play();
        }
        if (Input.GetButton("Fire2") && b2_timer > b2_interval)
        {
            b2_timer = 0;
            GameObject bullet = Instantiate(m_bullet2);
            bullet.transform.position = m_muzzle.transform.position;
            //m_audio.Play();
        }
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * _shipspeed_h, ForceMode2D.Force);
        m_rb.AddForce(Vector2.up * m_v * _shipspeed_v, ForceMode2D.Force);
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("HIGHSPEED MODE!!!");
            Time.timeScale = 1f*_highspeed;
        }
    }
}
