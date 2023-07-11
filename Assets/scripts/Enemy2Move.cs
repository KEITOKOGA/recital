using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2Move : DefaultEnemyMove
{
    [SerializeField] private GameObject e_upperbullet = default;
    [SerializeField] private GameObject e_underbullet = default;
    GameObject[] bullets = new GameObject[3];

    public override void Set()
    {
        _Movespeed = 25f;
        _Backspeed = 15f;
        bullets[0] = e_bullet;
        bullets[1] = e_underbullet;
        bullets[2] = e_upperbullet;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (b_timer > b_interval)
        {
            b_timer = 0;
            //GameObject bullet = Instantiate(e_bullet);
            //GameObject upperbullet = Instantiate(e_upperbullet);
            //GameObject under

            //bullet.transform.position = e_muzzle.transform.position;

            for(int i = 0; i < 3; i++) 
            {
                Instantiate(bullets[i], e_muzzle.transform.position, Quaternion.identity);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            sManager.SetScore_enemy2();
        }
    }
}
