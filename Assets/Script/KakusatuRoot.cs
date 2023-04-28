using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakusatuRoot : MonoBehaviour
{
    float speed = 5f;
    [SerializeField] Kakusatu kakusatu;
    [SerializeField] Transform _root = null;
    GameObject player;
    ObjectPool<Kakusatu> kakusatuPool = new ObjectPool<Kakusatu>();
    int intervalcount = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        kakusatuPool.SetBaseObj(kakusatu, _root);
        kakusatuPool.SetCapacity(100);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        transform.Rotate(new Vector3(0, 0, speed * -360 * Time.deltaTime));
        if (/*KillCount._KillCount > intervalcount &&*/ Input.GetKeyDown(KeyCode.Space))
        {
            var script = kakusatuPool.Instantiate();
            script.transform.position = player.transform.position + new Vector3(0, 2.6f, 0);
            //intervalcount += 10;
            Debug.Log("•KŽE‹Z");
        }
    }
}
