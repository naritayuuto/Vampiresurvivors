using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string LoadSceneName = "scene�̖��O";
    [SerializeField] Image fadePanel = null;
    [SerializeField] float fadetime = 1f;
    GameObject playerhp;
    bool LoadStart = false;

    // Update is called once per frame
    void Update()
    {
        if(LoadStart)//true��������
        {
            if(fadePanel)
            {
                fadePanel.DOColor(Color.black, fadetime).OnComplete(() => SceneManager.LoadScene(LoadSceneName));
                LoadStart = false;
                Debug.Log("�J�ڊ���");
            }
        }
    }
    public void LoadScene()
    {
        LoadStart = true;
    }
}
