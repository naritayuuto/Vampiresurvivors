using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerspeed = 0f;
    [SerializeField] float _shootTime = 0.3f;
    List<ISkill> _skill = new List<ISkill>();
    float _timer = 0.0f;
    static int playerHP = 100;
    Vector2 lastMovedDirection;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;

    public static int PlayerHP { get => playerHP; set => playerHP = value; }

    void Awake()
    {
        GameManager.Instance.SetPlayer(this);

        
    }
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = Direction(h, v);
        transform.position += new Vector3(h * playerspeed * Time.deltaTime, v * playerspeed * Time.deltaTime, 0);

        //���E�̌�����ς��邱�ƂŃA�j���[�V�������E�����i�������j�ɂ��邱�Ƃ��ł���
        if (dir.x != 0)
        {
            sprite.flipX = (dir.x < 0);
        }

        animate(dir.x, dir.y);
        lastMovedDirection = dir;
    }

    Vector2 Direction(float x, float y)
    {
        Vector2 dir = new Vector2(x,y);

        if (lastMovedDirection == Vector2.zero)
        {
            if (dir.x != 0 && dir.y != 0)
            {
                dir.y = 0;
            }
        }
        else if (lastMovedDirection.x != 0)
        {
            dir.y = 0;
        }
        else if (lastMovedDirection.y != 0)
        {
            dir.x = 0;
        }

        return dir;
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
        var having = _skill.Where(s => s.SkillId == (SkillDef)skillId);
        if (having.Count() > 0)
        {
            having.Single().Levelup();
        }
        else
        {
            ISkill newSkill = null;
            switch ((SkillDef)skillId)
            {
                case SkillDef.ShotBullet:
                    newSkill = new ShotBullet();
                    break;

                case SkillDef.AreaAttack:
                    newSkill = new AreaAttack();
                    break;
            }

            if (newSkill != null)
            {
                newSkill.Setup();
                _skill.Add(newSkill);
            }
        }
    }
}
