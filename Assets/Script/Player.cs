using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerspeed = 3f;
    [Tooltip("�v���C���[���������Ă���X�L��")]
    List<ISkill> _skill = new List<ISkill>();
    Vector2 lastMovedDirection;
    Vector3 playerpos;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    Vector2 dir;
    public Vector3 Playerpos { get => playerpos; set => playerpos = value; }
    public Vector2 LastMovedDirection { get => lastMovedDirection;}



    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = transform.position; 
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

         dir = new Vector2(h, v).normalized * playerspeed;
        //transform.up = dir;
        rb.velocity = dir;

        //���E�̌�����ς��邱�ƂŃA�j���[�V�������E�����i�������j�ɂ��邱�Ƃ��ł���
        if (dir.x != 0)
        {
            sprite.flipX = dir.x < 0;
        }
        animate(dir.x, dir.y);
        lastMovedDirection = dir;
        Debug.Log(lastMovedDirection);
    }

    void animate(float x,float y)
    {
        if(anim == null)
        {
            return;
        }
        if(x != 0 || y != 0)
        {
            anim.Play("Playerright");
        }
        else
        {
            if(lastMovedDirection.x != 0 || lastMovedDirection.y != 0)
            {
                anim.Play("Player-Idle-right");
            }
        }
    }
    public void SpeedUp()
    {
        playerspeed = playerspeed * 1.1f;
    }
}
