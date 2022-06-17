using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resultview : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Resulttime;
    [SerializeField] TextMeshProUGUI KillEnemy;
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI Heal;
    [SerializeField] TextMeshProUGUI Speedup;
    [SerializeField] TextMeshProUGUI Weaponpower;
    [SerializeField] TextMeshProUGUI Weaponspeed;
    // Start is called before the first frame update
    void Start()
    {
        Resulttime.text =  "ClearTime"Å@+ "     " + Timer.Setminute.ToString("00") + ":" + Mathf.Floor(Timer.Setsecondes).ToString("00");//D2Ç∆ë≈Ç¬Ç∆ÉGÉâÅ[î≠ê∂
        KillEnemy.text = "KillCount" + "     " + KillCount._KillCount.ToString();
        Level.text = "Level" + Expbar.Level.ToString();
        Heal.text = "Heal" + "            " + Levelup.CountHeal.ToString();
        Speedup.text = "SpeedUp" + "         " + Levelup.CountPlayerSpeed.ToString();
        Weaponpower.text = "WeaponPowerUp" + "     " + Levelup.CountWeaponPowerUp.ToString();
        Weaponspeed.text = "WeaponSpeedUp" + "     " + Levelup.CountWeaponSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
