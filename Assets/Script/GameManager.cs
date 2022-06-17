using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager
{
    static private GameManager instance = new GameManager();
    static public GameManager Instance => instance;

    List<Enemy> _enemies = new List<Enemy>();
    public void Setup()
    {
        //ObjectPool‚ÉˆË‘¶‚µ‚Ä‚¢‚é
        _enemies = GameObject.FindObjectsOfType<Enemy>(true).ToList();
    }

    static public List<Enemy> EnemyList => Instance._enemies;

}