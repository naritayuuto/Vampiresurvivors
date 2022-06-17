using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kakusatu : MonoBehaviour, IObjectPool
{
    Enemy enemy;
    float enemyhp;
    float time;
    float interval = 3f;
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
        time += Time.deltaTime;
        if (time >= interval)
        {
            Destroy();
            time = time - interval;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.GetComponent<Enemy>();
            enemyhp = enemy.Hp;
            enemy.Damage(enemyhp);
        }
    }
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
