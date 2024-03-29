using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager instance = default;
    static public GameManager Instance => instance;
    [SerializeField, Tooltip("プレイヤー")]
    Player _player = null;

    List<Enemy> _enemies = new List<Enemy>();
    public void Setup()
    {
        //ObjectPoolに依存している
        _enemies = GameObject.FindObjectsOfType<Enemy>(true).ToList();
    }
    static public List<Enemy> EnemyList => Instance._enemies;

    public Player Player => _player;
}