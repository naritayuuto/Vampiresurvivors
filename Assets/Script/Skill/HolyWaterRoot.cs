using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterRoot : ISkill
{
    public SkillDef SkillId => SkillDef.HolyWater;
    ObjectPool<HolyWater> _HolyWaterPool = new ObjectPool<HolyWater>();
    IntervalTimer timer = new IntervalTimer();
    [Tooltip("������")]
    const int _capacity = 100;
    [Tooltip("�v���C���[�̎���A�͈͓������߂邽�߂Ɏg�p")]
    const int _dis = 3;
    float _interval = 5f;
    [Tooltip("���x���A�b�v���Ɍ��炷����")]
    const float _reduceTime = 0.5f;
    [Tooltip("�v���C���[����ǂꂾ�����ꂽ�ꏊ�ɗ��Ƃ���")]
    Vector2 _distanceFromTarget;
    Vector3 _player;
    public void SetUp()
    {
        timer.Setup(_interval);
        HolyWater prefab = Resources.Load<HolyWater>("HolyWater");
        Transform root = SkillManager.Instance.ObjectRoot;
        _HolyWaterPool.SetBaseObj(prefab, root);
        _HolyWaterPool.SetCapacity(_capacity);
        _player = GameManager.Instance.Player.transform.position;
    }
    public void LevelUp()
    {
        _interval -= _reduceTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer.RunTimer())//true�̏ꍇ
        {
            Vector2 targetpos = new Vector2(Random.Range(_player.x - _dis, _player.x + _dis), Random.Range(_player.y - _dis, _player.y + _dis));
            var script = _HolyWaterPool.Instantiate();
            script.transform.position = targetpos;
        }
    }
}
