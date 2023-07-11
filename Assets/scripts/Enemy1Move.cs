using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1Move : DefaultEnemyMove
{
    public override void Set()
    {
        base.Set();
    }
    public override void FixedUpdate()
    {
         base.FixedUpdate();
        if (b_timer > b_interval)
        {
            b_timer = 0;
            GameObject bullet = Instantiate(e_bullet);
            bullet.transform.position = e_muzzle.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet") 
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            sManager.SetScore_enemy1();
        }
    }
}
