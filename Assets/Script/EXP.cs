using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    SpriteRenderer _image;
    Collider2D collider;
    [SerializeField] int exp = 3;
    Expbar expbar;

    // Start is called before the first frame update
    void Start()
    {
        expbar = GameObject.Find("EXPbar").GetComponent<Expbar>();
        _image = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            expbar.GetExperience(exp);
            Destroy(gameObject);
        }
    }
}
