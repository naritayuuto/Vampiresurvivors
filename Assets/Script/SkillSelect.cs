using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class SkillSelect : MonoBehaviour
{
    [SerializeField] List<GameObject> _selectList;
    
    List<SkillSelectTable> _selectTable = new List<SkillSelectTable>();//GameData
    List<TMPro.TextMeshProUGUI> _selectText = new List<TMPro.TextMeshProUGUI>();

    private void Start()
    {
        
    }
}
