using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPplayer2Controller : MonoBehaviour
{
    [SerializeField] float _shipspeed_h = 5f; //自機の水平方向の速度
    [SerializeField] float _shipspeed_v = 5f; //自機の垂直方向の速度
    [SerializeField] Transform p2_muzzle = default; //銃口の位置
    [SerializeField] GameObject p2_bullet = default; //弾1
    [SerializeField] float p2_interval = 0.5f;
    Rigidbody2D m_rb = default;
    float p2_timer;
    void Start()
    {
        p2_timer = p2_interval;
        m_rb = GetComponent<Rigidbody2D>();
        //m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        p2_timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.KeypadEnter) && p2_timer > p2_interval)
        {
            p2_timer = 0;
            GameObject bullet = Instantiate(p2_bullet);
            bullet.transform.position = p2_muzzle.transform.position;
            //m_audio.Play();
        }
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_rb.AddForce(Vector2.up * _shipspeed_v, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_rb.AddForce(Vector2.down * _shipspeed_v, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rb.AddForce(Vector2.left * _shipspeed_h, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rb.AddForce(Vector2.right * _shipspeed_h, ForceMode2D.Force);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player1bullet")
        {
            SceneManager.LoadScene("Player1winScene");
        }
    }
}
