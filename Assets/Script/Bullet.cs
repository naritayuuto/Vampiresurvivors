using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IObjectPool
{
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] Vector3 Up = Vector3.up;
    float bulletdamage;
    [SerializeField] float damagemin = 5f;
    [SerializeField] float damagemax = 7f;
    Rigidbody2D rb;
    SpriteRenderer _image;
    Collider2D collider;
    float time;
    float interval = 7f;
    // Start is called before the first frame update
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
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
            bulletdamage = Random.Range(damagemin, damagemax);
            collision.GetComponent<Enemy>().Damage(bulletdamage);
        }
    }
    bool _isActrive = false;
    public bool IsActive => _isActrive;

    public float Interval { get => interval; set => interval = value; }

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
