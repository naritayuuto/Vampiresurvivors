using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPool
{
    [SerializeField] float _speed = 10;
    [SerializeField] float pw = 3.0f;
    float hp = 10;
    float damage = 0;
    [SerializeField] EXP exp;
    GameObject player;
    HP h;
    Rigidbody2D rb;
    SpriteRenderer _image;
    Collider2D collider;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        _image = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    void Start()
    {
        h = GameObject.Find("Player").GetComponent<HP>();
    }
    void Update()
    {
        if (!IsActive) return;
        var dir =  (player.transform.position - transform.position).normalized * _speed;
        rb.velocity = dir;
    }

    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            Destroy();
            hp += 10;
            KillCount._KillCount++;
        }
        //TODO
        //GameManager.Instance.GetExperience(1);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            damage = pw * Time.deltaTime;
            h.Damage(damage);
        }
    }
    //ObjectPool
    bool _isActrive = false;
    public bool IsActive => _isActrive;

    public float Hp { get => hp; set => hp = value; }

    public void DisactiveForInstantiate()
    {
        _image.enabled = false;
        collider.enabled = false;
        _isActrive = false;
    }
    public void Create()
    {
        _image.enabled = true;
        collider.enabled = true;
        _isActrive = true;
    }
    public void Destroy()
    {
        _image.enabled = false;
        collider.enabled = false;
        _isActrive = false;
    }
}