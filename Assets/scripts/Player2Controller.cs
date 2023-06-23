using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] float _shipspeed_h = 5f; //自機の水平方向の速度
    [SerializeField] float _shipspeed_v = 5f; //自機の垂直方向の速度
    [SerializeField] float _highspeed = 2; //shiftを押した際の加速度
    [SerializeField] Transform m_muzzle1 = default; //銃口の位置
    [SerializeField] Transform m_muzzle2 = default; //銃口の位置
    [SerializeField] GameObject m_bullet = default; //弾
    [SerializeField] float b1_interval = 2f;
    [SerializeField] float b2_interval = 10f;
    [SerializeField] float b1_intervalBuffer = 0;
    Rigidbody2D m_rb = default;
    float m_h;
    float m_v;
    float b1_timer;
    float b2_timer;
    void Start()
    {
        b1_timer = b1_interval;
        b2_timer = b2_interval;
        b1_intervalBuffer = b1_interval;
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

        if (Input.GetButton("Fire1") && b1_timer > b1_intervalBuffer)
        {
            b1_timer = 0;
            GameObject bullet1 = Instantiate(m_bullet);
            bullet1.transform.position = m_muzzle1.transform.position;
            GameObject bullet2 = Instantiate(m_bullet);
            bullet2.transform.position = m_muzzle2.transform.position;
            //m_audio.Play();
        }
        
        if (Input.GetButton("Fire2") && b2_timer > b2_interval)
        {
            b2_timer = 0;
            b1_intervalBuffer = .1f;
            //m_audio.Play();
        }
        
        if (b2_timer > 5f)
        {
            b1_intervalBuffer = b1_interval;
        }
        
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
