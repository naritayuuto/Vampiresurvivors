using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class HP : MonoBehaviour
{
    [SerializeField] Slider slider;
    float playerhp = 100;
    float playermaxhp = 0;
    SceneLoader scene;
    // Start is called before the first frame update
    void Start()
    {
        //slider.maxValue = Player.PlayerHP;
        playermaxhp = playerhp;
        scene = GameObject.Find("Panel").GetComponent<SceneLoader>();
    }
    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0)
        {
            scene.LoadScene();
        }
    }
    public void Damage(float damage)
    {
        //slider.value -= damage;
        playerhp -= damage;
        slider.value = playerhp / playermaxhp;
    }
}
