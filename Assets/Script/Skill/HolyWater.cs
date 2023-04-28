using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWater : MonoBehaviour, IObjectPool, ISkill
{
    public SkillDef SkillId => SkillDef.HolyWater;
    SpriteRenderer _image;
    Collider2D collider;
    float _damage = 10f;
    [SerializeField, Tooltip("ダメージの最低値")]
    float _damagemin = 9f;
    [SerializeField, Tooltip("ダメージの最高値")]
    float _damagemax = 11f;
    [Tooltip("時間")]
    float _time = 0f;
    [Tooltip("画面内に映っていられる時間")]
    float _interval = 2f;
    [Tooltip("レベルアップ時に加算する値")]
    const float _addInterval = 0.5f;
    [Tooltip("画面内に映っていたらTrue")]
    bool _isActrive = false;
    public bool IsActive => _isActrive;
    void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (!_isActrive)
        {
            return;
        }
        _time += Time.deltaTime;
        if (_time >= _interval)
        {
            Destroy();
        }
    }
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _damage = Random.Range(_damagemin, _damagemax);
            collision.GetComponent<Enemy>().Damage(_damage);
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
        _interval += _addInterval;
    }
}
