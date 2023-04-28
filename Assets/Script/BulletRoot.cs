using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRoot : MonoBehaviour
{
    [SerializeField] 
    float _speed = 1f;
    [SerializeField] 
    Bullet _bullet = null;
    [SerializeField] 
    Transform _root = null;
    Vector3 _upPos = new Vector3(0, 1, 0);
    [Tooltip("����")]
    float _time = 0f;
    [Tooltip("��������b��")]
    float _interval = 5f;
    GameObject player;
    [Tooltip("������")]
    const int _capacity = 100;
    [Tooltip("��]�����邽�߂Ɏg���l")]
    const int _angle = -360;
    [Tooltip("���x���A�b�v���ɉ��Z����l")]
    const float _addSpeed = 0.2f;
    [Tooltip("���x���A�b�v���ɐ����Ԋu���k�߂�l")]
    const float _shrinkInterval = 0.5f;
    ObjectPool<Bullet> bulletPool = new ObjectPool<Bullet>();
    // Start is called before the first frame update

    public void Start()
    {
        player = GameObject.Find("Player");
        bulletPool.SetBaseObj(_bullet, _root);
        bulletPool.SetCapacity(_capacity);
       
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
    public void Levelup()
    {
        _speed += _addSpeed;
        _interval -= _shrinkInterval;
    }
}
