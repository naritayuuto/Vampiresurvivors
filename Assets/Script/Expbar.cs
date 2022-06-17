using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Expbar : MonoBehaviour
{
    [SerializeField] Slider Expslider;
    TextMeshProUGUI text;
    float Borderline = 20;
    [SerializeField] Levelup levelup;
    int _stackLevelup = 0;
    static int _level = 1;

    static public int Level { get => _level; set => _level = value; }
    public int StackLevelup { get => _stackLevelup; set => _stackLevelup = value; }

    // Start is called before the first frame update
    void Start()
    {
        Expslider.maxValue = Borderline;
        text = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
    }
    public void GetExperience(int exp)
    {
        Expslider.value += exp;
       
        if (Expslider.value >= Borderline)
        {
            _level++;
            Borderline = Borderline * 1.1f;
            Expslider.maxValue = Borderline;
            Expslider.value -= Borderline;
            text.text = "Lv." + _level.ToString("D2");
            if (Time.timeScale > 0.99f)
            {
                levelup.SelectStart();
                Time.timeScale = 0;//時間を止めている
            }
            else
            {
                _stackLevelup++;//連続的レベルアップが起こった場合
            }
        }
    }
}
