using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, IObjectPool, ISkill
{
    public SkillDef SkillId => SkillDef.Knife;
    SpriteRenderer _image;
    Collider2D collider;
    Rigidbody2D _rb;
    [Tooltip("�i�C�t�����ł����X�s�[�h�A�v���C���[�̈ړ����x�~_speed")]
    float _speed = 1.1f;
    float _damage = 8f;
    [SerializeField, Tooltip("�_���[�W�̍Œ�l")]
    float _damagemin = 7f;
    [SerializeField, Tooltip("�_���[�W�̍ō��l")]
    float _damagemax = 9f;
    [Tooltip("����")]
    float _time = 0f;
    [Tooltip("��ʓ��ɉf���Ă����鎞��")]
    float _interval = 5f;
    [Tooltip("���x���A�b�v����damage�̍ő�A�Œ�l�ɉ��Z����l")]
    const int _addDamage = 2;
    [Tooltip("��ʓ��ɉf���Ă�����True")]
    bool _isActrive = false;
    public bool IsActive => _isActrive;
    void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            return;
        }
        _rb.AddForce(GameManager.Instance.Player.LastMovedDirection * _speed);
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
    public void Levelup()
    {
        _damagemin += _addDamage;
        _damagemax += _addDamage;
    }
}
