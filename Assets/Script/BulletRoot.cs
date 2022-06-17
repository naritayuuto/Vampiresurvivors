using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRoot : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Bullet bullet = null;
    [SerializeField] Transform _root = null;
    Vector3 uppos = new Vector3(0, 1, 0);
    float time = 0f;
    float interval = 5f;
    GameObject player;
    ObjectPool<Bullet> bulletPool = new ObjectPool<Bullet>();
   
    // Start is called before the first frame update

    public void Start()
    {
        player = GameObject.Find("Player");
        bulletPool.SetBaseObj(bullet, _root);
        bulletPool.SetCapacity(100);
       
    }

    // Update is called once per frame
    public void Update()
    {
        this.transform.position = player.transform.position;
        time += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, speed * -360 * Time.deltaTime));
        if (time >= interval)
        {
            Generate();
            time -= interval;
        }
    }
    public void Generate()
    {
        var script = bulletPool.Instantiate();
        script.transform.position = player.transform.position + uppos;
        Debug.Log("bulletseisei");
    }
    public void Levelup()
    {
        interval -= -0.5f;
    }
}
