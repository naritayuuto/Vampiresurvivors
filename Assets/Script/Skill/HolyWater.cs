using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWater : MonoBehaviour, IObjectPool, ISkill
{
    public SkillDef SkillId => SkillDef.HolyWater;
    SpriteRenderer _image;
    Collider2D collider;
    float _damage = 10f;
    [SerializeField, Tooltip("�_���[�W�̍Œ�l")]
    float _damagemin = 9f;
    [SerializeField, Tooltip("�_���[�W�̍ō��l")]
    float _damagemax = 11f;
    [Tooltip("����")]
    float _time = 0f;
    [Tooltip("��ʓ��ɉf���Ă����鎞��")]
    float _interval = 2f;
    [Tooltip("���x���A�b�v���ɉ��Z����l")]
    const float _addInterval = 0.5f;
    [Tooltip("��ʓ��ɉf���Ă�����True")]
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
