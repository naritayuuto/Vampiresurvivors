using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRoot : MonoBehaviour,ISkill
{
    public SkillDef SkillId => SkillDef.Bullet;
    [SerializeField] 
    float _speed = 1f;
    [SerializeField] 
    Bullet _bullet = null;
    [SerializeField] 
    Transform _root = null;
    Vector3 _upPos = new Vector3(0, 1, 0);
    [Tooltip("時間")]
    float _time = 0f;
    [Tooltip("生成する秒数")]
    float _interval = 5f;
    Player player;
    [Tooltip("生成数")]
    const int _capacity = 100;
    [Tooltip("回転させるために使う値")]
    const int _angle = -360;
    [Tooltip("レベルアップ時に加算する値")]
    const float _addSpeed = 0.2f;
    [Tooltip("レベルアップ時に生成間隔を縮める値")]
    const float _shrinkInterval = 0.5f;
    ObjectPool<Bullet> bulletPool = new ObjectPool<Bullet>();
    // Start is called before the first frame update
    public void SetUp()
    {
        bulletPool.SetBaseObj(_bullet, _root);
        bulletPool.SetCapacity(_capacity);
    }
    public void Start()
    {
        player = GameManager.Instance.Player;   
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = player.transform.position;
        _time += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, _angle * Time.deltaTime));
        if (_time >= _interval)
        {
            Generate();
            _time = 0;
        }
    }
    public void Generate()
    {
        var script = bulletPool.Instantiate();
        script.transform.position = player.transform.position + _upPos;
        Debug.Log("bulletseisei");
    }
    public void LevelUp()
    {
        _speed += _addSpeed;
        _interval -= _shrinkInterval;
    }
}
