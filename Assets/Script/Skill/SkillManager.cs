using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    static private SkillManager instance = default;

    static public SkillManager Instance => instance;

    [SerializeField,Tooltip("����̐e�I�u�W�F�N�g")]
    Transform objectRoot = null;
    public Transform ObjectRoot { get => objectRoot; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
