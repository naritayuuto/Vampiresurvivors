using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, IObjectPool, ISkill
{
    public SkillDef SkillId => SkillDef.Knife;
    SpriteRenderer _image;
    Collider2D collider;
    Rigidbody2D _rb;
    [Tooltip("ナイフが飛んでいくスピード、プレイヤーの移動速度×_speed")]
    float _speed = 1.1f;
    float _damage = 8f;
    [SerializeField, Tooltip("ダメージの最低値")]
    float _damagemin = 7f;
    [SerializeField, Tooltip("ダメージの最高値")]
    float _damagemax = 9f;
    [Tooltip("時間")]
    float _time = 0f;
    [Tooltip("画面内に映っていられる時間")]
    float _interval = 5f;
    [Tooltip("レベルアップ時にdamageの最大、最低値に加算する値")]
    const int _addDamage = 2;
    [Tooltip("画面内に映っていたらTrue")]
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
