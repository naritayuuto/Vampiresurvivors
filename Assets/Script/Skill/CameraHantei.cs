using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHantei : MonoBehaviour
{
    public static CameraHantei instance = default;
    List<Enemy> enemys = new List<Enemy>();
    public List<Enemy> Enemys => enemys;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(TryGetComponent<Enemy>(out Enemy enemy))
        {
            if(enemys.Contains(enemy) == false)
            {
                enemys.Add(enemy);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemys.Remove(collision.GetComponent<Enemy>());
    }
}
