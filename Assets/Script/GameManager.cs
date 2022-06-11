using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    // Start is called before the first frame update
    List<Enemy> _enemies = new List<Enemy>();
    List<Bullet> bullet = new List<Bullet>();
    public void Setup()
    {
        //ObjectPool‚ÉˆË‘¶‚µ‚Ä‚¢‚é
        _enemies = GameObject.FindObjectsOfType<Enemy>(true).ToList();
        bullet = GameObject.FindObjectsOfType<Bullet>(true).ToList();
    }
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    static public List<Enemy> EnemyList => Instance._enemies;
    static public List<Bullet> BulletList => Instance.bullet; 
}

    // Update is called once per frame

