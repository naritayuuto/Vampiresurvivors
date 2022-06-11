using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{

    [SerializeField] Bullet bullet = null;
    [SerializeField] Transform _root = null;
    float time;
    float interval = 1f;
    Vector2 lastpos;
    Player player;
    ObjectPool<Bullet> bulletPool = new ObjectPool<Bullet>();

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        bulletPool.SetBaseObj(bullet, _root);
        bulletPool.SetCapacity(100);

        GameManager.Instance.Setup();
    }
    // Update is called once per frame
    void Update()
    {     
        time += Time.deltaTime;
        if(time >= interval)
        {
            lastpos = player.LastMovedDirection;
            Generate();
            time -= interval;
        }
    }
    public void Generate()
    {
        var script = bulletPool.Instantiate();
        script.transform.position = Player.Playerpos;
    }
    
}
