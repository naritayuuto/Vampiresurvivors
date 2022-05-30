using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //slider.maxValue = playerHP;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("SliderCanvas").transform.LookAt(GameObject.Find("ålŒö‚Ì–¼‘O").transform);
    }
}
