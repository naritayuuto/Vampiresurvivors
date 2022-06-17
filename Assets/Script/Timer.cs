using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timer;
    [SerializeField] Slider hp;
    [SerializeField] GameObject result;
    [SerializeField] TextMeshProUGUI Resulttimer;
    int minute = 0;
    float seconds = 0;

    static int setminute = 0;
    static float setsecondes = 0;

    static public int Setminute { get => setminute; set => setminute = value; }
    static public float Setsecondes { get => setsecondes; set => setsecondes = value; }

    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        Resulttimer = GetComponent<TextMeshProUGUI>();
        result.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        timer.text = minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
        if(hp.value <= 0)
        {
            Time.timeScale = 0;
            result.SetActive(true);
            setminute = minute;
            setsecondes = seconds;
        }
    }
}
