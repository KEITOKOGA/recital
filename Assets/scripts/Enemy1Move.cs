using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    [SerializeField] float _Movespeed = 0;
    [SerializeField] float _Backspeed = 0;
    [SerializeField] float _Movetime = 0;
    [SerializeField] float _Staytime = 5f;
    [SerializeField] float _Backtime = 10f;
    [SerializeField] float _LifeTime = 10f;
    [SerializeField] Transform e_muzzle = default;
    [SerializeField] GameObject e_bullet = default;
    [SerializeField] float b_interval = 1f;
    Rigidbody2D e_rb = default;
    float b_timer;

    private void Start()
    {
        b_timer = b_interval;
        e_rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        b_timer += Time.deltaTime;
        _Movetime += Time.deltaTime;
        if (_Movetime < _Staytime)
        {
            e_rb.AddForce(Vector2.left * _Movespeed, ForceMode2D.Force);
        }else if(_Movetime <_Backtime)
        {
            ;
        }
        else 
        {
            e_rb.AddForce(Vector2.right * _Backspeed * 2, ForceMode2D.Force);
        }
        if (b_timer > b_interval)
        {
            b_timer = 0;
            GameObject bullet = Instantiate(e_bullet);
            bullet.transform.position = e_muzzle.transform.position;
        }
        Destroy(this.gameObject, _LifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet") 
        {
            Destroy(this.gameObject);
        }
    }
}
