using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    Text text;
    static int _killCount = 0;

    public static int _KillCount { get => _killCount; set => _killCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _KillCount.ToString("åÇîjêî" +"0000");
    }
}
