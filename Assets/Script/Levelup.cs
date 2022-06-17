using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Levelup : MonoBehaviour

{
    [SerializeField] GameObject[] button;
    [SerializeField] TextMeshProUGUI Heal;
    [SerializeField] TextMeshProUGUI Playerspeed;
    [SerializeField] TextMeshProUGUI Weaponspeed;
    [SerializeField] TextMeshProUGUI Weaponpower;
    [SerializeField] Expbar expbar;
    bool _startEvent = false;
    [SerializeField] HP playerhp;
    [SerializeField] Player playerspeed;
    [SerializeField] Bullet Bulletpower;
    [SerializeField] BulletRoot Bulletspeed;
    static int countHeal = 0;
    static int countPlayerSpeed = 0;
    static int countWeaponPowerUp = 0;
    static int countWeaponSpeed = 0;
    public static int CountHeal { get => countHeal; }
    public static int CountPlayerSpeed { get => countPlayerSpeed; }
    public static int CountWeaponPowerUp { get => countWeaponPowerUp; }
    public static int CountWeaponSpeed { get => countWeaponSpeed; }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (_startEvent)
        {
            SelectStart();
            _startEvent = false;
        }
        if(countPlayerSpeed >= 8)
        {
            button[1].SetActive(false);
        }
        if (countWeaponPowerUp >= 8)
        {
            button[2].SetActive(false);
        }
        if (countWeaponSpeed >= 8)
        {
            button[3].SetActive(false);
        }
    }
    public void SelectStartDelay()
    {
        _startEvent = true;
    }
    public void SelectStart()//ExpvarのGetExperience()で呼ぶ
    {
        this.gameObject.SetActive(true);
        Heal.text = "Heal";
        Playerspeed.text = "SpeedUp";
        Weaponpower.text = "WeaponPowerUp";
        Weaponspeed.text = "WeaponSpeedUp";
    }
    public enum skill
    {
        heal = 0,
        speedup = 1,
        weaponpowerup = 2,
        weaponspeedup = 3
    }
    public void OnClickBottonHeal()
    {
        playerhp.Heal();
        countHeal++;
        StackLevelUp();
        this.gameObject.SetActive(false);
    }

    public void OnClickBottenPlayerSpeed()
    {
            playerspeed.speedup();
            countPlayerSpeed++;
            StackLevelUp();
            this.gameObject.SetActive(false);
    }
            
    public void OnClickBottenWeaponPowerUp()
    {
        Bulletpower.Weaponpower();
        countWeaponPowerUp++;
        StackLevelUp();
        this.gameObject.SetActive(false);
    }

    public void OnClickBottenWeaponSpeed()
    {
        Bulletspeed.Levelup();
        countWeaponSpeed++;
        StackLevelUp();
        this.gameObject.SetActive(false);
    }
            
    public void StackLevelUp()
    {
        if (expbar.StackLevelup > 0)
        {
            SelectStartDelay();//連続でアップしたレベル分スキルを選ぶ。
            expbar.StackLevelup--;
        }
        else
        {
            Time.timeScale = 1;
        }
        this.gameObject.SetActive(false);
    }
}