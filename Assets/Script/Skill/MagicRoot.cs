using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRoot : ISkill
{
    public SkillDef SkillId => SkillDef.Magic;
    ObjectPool<Magic> _MagicPool = new ObjectPool<Magic>();
    IntervalTimer timer = new IntervalTimer();
    [Tooltip("生成数")]
    const int _capacity = 100;
    [Tooltip("一回に打ち出す魔法の上限")]
    int _shotCount = 1;
    [Tooltip("魔法を当てられる距離")]
    float distance = 1f;
    float _interval = 1f;
    [Tooltip("配列の要素をずらすために使用")]
    const int _one = 1;
    public void SetUp()
    {
        timer.Setup(_interval);
        Magic prefab = Resources.Load<Magic>("Magic");
        Transform root = SkillManager.Instance.ObjectRoot;
        _MagicPool.SetBaseObj(prefab, root);
        _MagicPool.SetCapacity(_capacity);
    }
    public void LevelUp()
    {
        _shotCount++;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer.RunTimer())//trueの場合
        {
            List<Enemy> enemys = CameraHantei.instance.Enemys;
            Enemy[] targets = new Enemy[_shotCount];
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i] = enemys[i];
            }
            for (int i = 0; i < _shotCount; ++i)
            {
                var script = _MagicPool.Instantiate();
                script.transform.position = GameManager.Instance.Player.transform.position;
                script.TargetSet(targets[i]);
            }
        }
    }
}
