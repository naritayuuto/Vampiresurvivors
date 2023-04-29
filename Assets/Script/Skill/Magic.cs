using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour, IObjectPool
{
    Rigidbody2D _rb;
    SpriteRenderer _image;
    Collider2D collider;
    Enemy _terget = null;
    float _damage = 8f;
    [SerializeField, Tooltip("�_���[�W�̍Œ�l")]
    float _damagemin = 7f;
    [SerializeField, Tooltip("�_���[�W�̍ō��l")]
    float _damagemax = 9f;
    float _dis = 0f;
    float _speed = 9f;
    [Tooltip("����")]
    float _time = 0f;
    [Tooltip("��ʓ��ɉf���Ă����鎞��")]
    float _interval = 5f;
    [Tooltip("��ʓ��ɉf���Ă�����True")]
    bool _isActrive = false;
    public bool IsActive => _isActrive;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _image = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    public void TargetSet(Enemy enemy)
    {
        _terget = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isActrive)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _terget.transform.position, _speed * Time.deltaTime);
        _time += Time.deltaTime;
        if (_time >= _interval)
        {
            Destroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _damage = Random.Range(_damagemin, _damagemax);
            collision.GetComponent<Enemy>().Damage(_damage);
            Destroy();
        }
    }
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
