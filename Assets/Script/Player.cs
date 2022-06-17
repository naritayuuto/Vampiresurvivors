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
    List<ISkill> _skill = new List<ISkill>();
    Vector2 lastMovedDirection;
    Vector3 playerpos;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    Vector2 dir;
    public Vector3 Playerpos { get => playerpos; set => playerpos = value; }



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

        //左右の向きを変えることでアニメーションを右だけ（左だけ）にすることができる
        if (dir.x != 0)
        {
            sprite.flipX = dir.x < 0;
        }
        animate(dir.x, dir.y);
        lastMovedDirection = dir;
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
    //public void AddSkill(int skillId)
    //{
    //    var having = _skill.Where(s => s.SkillId == (SkillDef)skillId);
    //    if (having.Count() > 0)
    //    {
    //        having.Single().Levelup();//取ってたらそのレベルを上げる
    //    }
    //    else//スキルの追加
    //    {
    //        ISkill newSkill = null;
    //        switch ((SkillDef)skillId)
    //        {
    //            case SkillDef.Bullet:
    //                newSkill = new BulletRoot();
    //                break;

    //            case SkillDef.AreaAttack:
    //                newSkill = new AreaAttack();
    //                break;
    //        }

    //        if (newSkill != null)
    //        {
    //            newSkill.Setup();
    //            _skill.Add(newSkill);
    //        }
    //    }
    //}
    public void speedup()
    {
        playerspeed = playerspeed * 1.1f;
    }
}
