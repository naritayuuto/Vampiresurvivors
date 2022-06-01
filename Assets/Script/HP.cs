using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider slider;
    int playermaxhp;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = Player.PlayerHP;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int damage)
    {
        slider.value = slider.value - damage;
    }
}
