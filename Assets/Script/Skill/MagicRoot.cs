using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRoot : ISkill
{
    public SkillDef SkillId => SkillDef.Magic;
    ObjectPool<Magic> _MagicPool = new ObjectPool<Magic>();
    IntervalTimer timer = new IntervalTimer();
    [Tooltip("������")]
    const int _capacity = 100;
    [Tooltip("���ɑł��o�����@�̏��")]
    int _shotCount = 1;
    [Tooltip("���@�𓖂Ă��鋗��")]
    float distance = 1f;
    float _interval = 1f;
    [Tooltip("�z��̗v�f�����炷���߂Ɏg�p")]
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
        if(timer.RunTimer())//true�̏ꍇ
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
