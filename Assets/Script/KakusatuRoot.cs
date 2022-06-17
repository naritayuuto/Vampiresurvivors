using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakusatuRoot : MonoBehaviour
{
    [SerializeField] Kakusatu kakusatu;
    [SerializeField] Transform _root = null;
    GameObject player;
    ObjectPool<Kakusatu> kakusatuPool = new ObjectPool<Kakusatu>();
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
        if (/*KillCount._KillCount > 10 &&*/ Input.GetKeyDown(KeyCode.Space))
        {
            var script = kakusatuPool.Instantiate();
            script.transform.position = player.transform.position + new Vector3(0, 1.35f, 0);
            Debug.Log("•KŽE‹Z");
        }
    }
}
