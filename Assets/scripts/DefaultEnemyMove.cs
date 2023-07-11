using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefaultEnemyMove : MonoBehaviour
{
    [SerializeField] protected float _Movespeed = 0;
    [SerializeField] protected float _Backspeed = 0;
    [SerializeField] private float _Movetime = 0;
    [SerializeField] private float _Staytime = 5f;
    [SerializeField] private float _Backtime = 10f;
    [SerializeField] private float _LifeTime = 10f;
    [SerializeField] protected Transform e_muzzle = default;
    [SerializeField] protected GameObject e_bullet = default;
    [SerializeField] protected float b_interval = 1f;
    protected Rigidbody2D e_rb = default;
    protected float b_timer;
    protected ScoreManager sManager;
    public void Start()
    {
        sManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        b_timer = b_interval;
        e_rb = GetComponent<Rigidbody2D>();
        Set();
    }

    public virtual void Set()
    {
        _Movespeed = 20f;
        _Backspeed = 10f;
    }


    public virtual void FixedUpdate()
    {
        Debug.Log("åƒÇŒÇÍÇƒÇÈÇÊÅ[");
        b_timer += Time.deltaTime;
        _Movetime += Time.deltaTime;
        if (_Movetime < _Staytime)
        {
            e_rb.AddForce(Vector2.left * _Movespeed, ForceMode2D.Force);
        }
        else if (_Movetime < _Backtime)
        {
            ;
        }
        else
        {
            e_rb.AddForce(Vector2.right * _Backspeed * 2, ForceMode2D.Force);
        }
        Destroy(this.gameObject, _LifeTime);
    }

    public virtual void Set(int a)
    {
        _Movespeed = 20f;
        _Backspeed = 10f;
    }

}
