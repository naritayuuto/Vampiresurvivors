using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterRoot : ISkill
{
    public SkillDef SkillId => SkillDef.HolyWater;
    ObjectPool<HolyWater> _HolyWaterPool = new ObjectPool<HolyWater>();
    IntervalTimer timer = new IntervalTimer();
    [Tooltip("生成数")]
    const int _capacity = 100;
    [Tooltip("プレイヤーの周り、範囲内を決めるために使用")]
    const int _dis = 3;
    float _interval = 5f;
    [Tooltip("レベルアップ時に減らす時間")]
    const float _reduceTime = 0.5f;
    [Tooltip("プレイヤーからどれだけ離れた場所に落とすか")]
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
        if (timer.RunTimer())//trueの場合
        {
            Vector2 targetpos = new Vector2(Random.Range(_player.x - _dis, _player.x + _dis), Random.Range(_player.y - _dis, _player.y + _dis));
            var script = _HolyWaterPool.Instantiate();
            script.transform.position = targetpos;
        }
    }
}
