using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    TextMeshProUGUI text;
    static int _killCount = 0;

    public static int _KillCount { get => _killCount; set => _killCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _KillCount.ToString("KillCount" +"0000");
    }
}
