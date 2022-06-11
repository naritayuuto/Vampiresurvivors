using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _time = 0.05f;
    [SerializeField] Enemy _prefab = null;
    [SerializeField] Transform _root = null;
    int random; 
    float _timer = 0.0f;
    float _cRad = 0.0f;
    Vector3 _popPos = new Vector3(0, 0, 0);

    ObjectPool<Enemy> _enemyPool = new ObjectPool<Enemy>();

    private void Start()
    {
        _enemyPool.SetBaseObj(_prefab, _root);
        _enemyPool.SetCapacity(300);

        GameManager.Instance.Setup();

        for (int i = 0; i < 3; ++i) Spawn();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _time)
        {
            Spawn();
            _timer -= _time;
        }
    }

    void Spawn()
    {
        random = UnityEngine.Random.Range(-20, 20);
        //当たり判定、scriptなどをtrueにする
        var script = _enemyPool.Instantiate();
        /*
        var go = GameObject.Instantiate(_prefab);
        var script = go.GetComponent<Enemy>();
       */
        _popPos.x = Player.Playerpos.x + random * Mathf.Cos(_cRad);
        _popPos.y = Player.Playerpos.y + random * Mathf.Sin(_cRad);
        script.transform.position = _popPos;
        _cRad += 0.1f;
        
        Debug.Log("seisei");
    }
}