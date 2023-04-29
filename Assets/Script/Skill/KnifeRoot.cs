using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeRoot : ISkill
{
    public SkillDef SkillId => SkillDef.Knife;
    ObjectPool<Knife> _KnifePool = new ObjectPool<Knife>();
    IntervalTimer timer = new IntervalTimer();
    [Tooltip("������")]
    const int _capacity = 100;
    float _interval = 3f;
    [Tooltip("���x���A�b�v���Ɍ��炷����")]
    const float _reduceTime = 0.5f;
    public void SetUp()
    {
        timer.Setup(_interval);
        Knife prefab = Resources.Load<Knife>("Knife");
        Transform root = SkillManager.Instance.ObjectRoot;
        _KnifePool.SetBaseObj(prefab, root);
        _KnifePool.SetCapacity(_capacity);
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
            var script = _KnifePool.Instantiate();
            script.transform.position = GameManager.Instance.Player.transform.position; ;
        }
    }
}
