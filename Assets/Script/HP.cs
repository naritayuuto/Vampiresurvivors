using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour//Player��HP��0�ɂȂ�����̏�����Timer�ōs���Ă���
{
    [SerializeField] Slider hpslider;
    float playerhp = 100;
    float playermaxhp = 0;

    // Start is called before the first frame update
    void Start()
    {
        //slider.maxValue = Player.PlayerHP;
        playermaxhp = playerhp;//���݂̍ő�HP
    }
    // Update is called once per frame
    public void Damage(float damage)
    {
        //slider.value -= damage;
        playerhp -= damage;
        hpslider.value = playerhp / playermaxhp;
    }

    public void Heal()
    {
        playerhp = 100;
        hpslider.value = playerhp / playermaxhp;
    }
}
