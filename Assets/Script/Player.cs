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
    [Tooltip("プレイヤーが所持しているスキル")]
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
    public void AddSkill(int skillId)
    {
        var skill = _skill.Where(s => s.SkillId == (SkillDef)skillId);
        if(skill.Count() > 0)//スキル取得が初めてでは無い場合
        {
            skill.Single().LevelUp();
        }
        else//スキル初取得（ゲーム開始前）
        {
            ISkill newSkill = null;
            switch ((SkillDef)skillId)
            {
                case SkillDef.Bullet:
                    BulletRoot bullet = new BulletRoot();
                    break;
                case SkillDef.Knife:
                    Knife knife = new Knife();
                    break;
                case SkillDef.Magic:
                    Magic magic = new Magic();
                    break;
                case SkillDef.HolyWater:
                    HolyWater holyWater = new HolyWater();
                    break;
            }
            if(newSkill != null)
            {
                newSkill.SetUp();
                _skill.Add(newSkill);
            }
        }
    }
    public void SpeedUp()
    {
        playerspeed = playerspeed * 1.1f;
    }
}
