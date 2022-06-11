using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IObjectPool
{
    [SerializeField] float bulletSpeed = 7f;
    static float bulletdamage = 3f;
    Vector3 _popPos = new Vector3(0, 0, 0);
    Player player;
    int count = 0;
    Rigidbody2D rb;
    SpriteRenderer _image;
    Collider2D collider;
    Vector2 playerdir;
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
        var dir = playerdir * bulletSpeed * Time.deltaTime;
        rb.velocity = dir;
        if (time >= interval)
        {
            Destroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           collision.GetComponent<Enemy>().Damage(Bulletdamage);
           Destroy();
        }
    }
    bool _isActrive = false;
    public bool IsActive => _isActrive;

    public static float Bulletdamage { get => bulletdamage; set => bulletdamage = value; }

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
