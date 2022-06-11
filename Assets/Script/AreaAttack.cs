using System;
using UnityEngine;

public class AreaAttack : ISkill
{
    public SkillDef SkillId => SkillDef.AreaAttack;
    IntervalTimer _timer = new IntervalTimer();
    public int damage;//��
    float _interval = 1.0f;
    int _maxAttackCount = 10;
    float _area = 5.0f;

    public void Setup()
    {
        _timer.Setup(_interval);
    }

    public void Update()
    {
        if (!_timer.RunTimer()) return;

        int attackCount = 0;
        var list = GameManager.EnemyList;
        Vector3 vec;
        foreach (var e in list)
        {
            if (!e.IsActive) continue;

            vec = e.transform.position - Player.Playerpos;
            if (vec.magnitude < _area)
            {
                e.Damage(damage);
                attackCount++;

                if (attackCount >= _maxAttackCount)
                {
                    break;
                }
            }
        }
    }

    public void Levelup()
    {
        _area += 5.0f;
    }
}