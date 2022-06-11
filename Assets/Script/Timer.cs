using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text text;
    static int minute = 0;
    float seconds = 0;
    public static int Minute { get => minute; set => minute = value; }

    void Start()
    {
        text = GetComponent<Text>();
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
        text.text = minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
    }
}
