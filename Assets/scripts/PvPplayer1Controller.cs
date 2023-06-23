using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPplayer1Controller : MonoBehaviour
{
    [SerializeField] float _shipspeed_h = 5f; //自機の水平方向の速度
    [SerializeField] float _shipspeed_v = 5f; //自機の垂直方向の速度
    [SerializeField] Transform p1_muzzle = default; //銃口の位置
    [SerializeField] GameObject p1_bullet = default; //弾1
    [SerializeField] float p1_interval = 0.5f;
    Rigidbody2D m_rb = default;
    float p1_timer;
    void Start()
    {
        p1_timer = p1_interval;
        m_rb = GetComponent<Rigidbody2D>();
        //m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        p1_timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && p1_timer > p1_interval)
        {
            p1_timer = 0;
            GameObject bullet = Instantiate(p1_bullet);
            bullet.transform.position = p1_muzzle.transform.position;
            //m_audio.Play();
        }
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        if (Input.GetKey(KeyCode.W))
        {
            m_rb.AddForce(Vector2.up * _shipspeed_v, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.S)) 
        {
            m_rb.AddForce(Vector2.down * _shipspeed_v, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.A))
        {
            m_rb.AddForce(Vector2.left * _shipspeed_h, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rb.AddForce(Vector2.right * _shipspeed_h, ForceMode2D.Force);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player2bullet")
        {
            SceneManager.LoadScene("Player2winScene");
        }
    }
}
