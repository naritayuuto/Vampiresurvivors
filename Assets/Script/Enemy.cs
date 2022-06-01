using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPool
{
    [SerializeField] float _speed = 10;
    [SerializeField] int pw = 3;
    static int hp = 10; 
    SpriteRenderer _image;
    Collider2D collider;
    void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!IsActive) return;

        Vector3 sub = GameManager.Player.transform.position - transform.position;
        sub.Normalize();

        transform.position += sub * _speed * Time.deltaTime;
    }

    public void Damage(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            Destroy();
        }
        //TODO
        GameManager.Instance.GetExperience(1);
    }

    public void Attack()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null && collision.gameObject.TryGetComponent(out HP hp))
        {
            hp.Damage(pw);
        }
    }
    //ObjectPool
    bool _isActrive = false;
    public bool IsActive => _isActrive;
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