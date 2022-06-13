using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager instance = new GameManager();
    static public GameManager Instance => instance;
    Player player;
    int _exp = 0;
    int _level = 1;
    int _stackLevelup = 0;
    List<Enemy> _enemies = new List<Enemy>();
    List<int> _passive = new List<int>();
    SkillSelect _sklSelect = null;


    public void Setup()
    {
        //ObjectPool‚ÉˆË‘¶‚µ‚Ä‚¢‚é
        _enemies = GameObject.FindObjectsOfType<Enemy>(true).ToList();
        _sklSelect = FindObjectOfType<SkillSelect>();
    }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            SceneManager.sceneLoaded += GameSceneLoad;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GameScene")
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }
    public void GetExperience(int exp)
    {
        _exp += exp;

        //level up
        if (GameData.LevelTable.Count > _level && _exp > GameData.LevelTable[_level])
        {
            _level++;

            if (Time.timeScale > 0.99f)
            {
                _sklSelect.SelectStart();
                Time.timeScale = 0;
            }
            else
            {
                _stackLevelup++;
            }
        }
    }

    public void LevelUpSelect(SkillSelectTable table)
    {
        switch (table.Type)
        {
            case SelectType.Skill:
                player.AddSkill(table.TargetId);
                break;

            case SelectType.Passive:
                _passive.Add(table.TargetId);
                break;

            case SelectType.Execute:
                //TODO:
                break;
        }

        if (_stackLevelup > 0)
        {
            _sklSelect.SelectStartDelay();
            _stackLevelup--;
        }
        else
        {
            Time.timeScale = 1;
        }
    }


    static public List<Enemy> EnemyList => Instance._enemies;


    static public int Level => Instance._level;
}