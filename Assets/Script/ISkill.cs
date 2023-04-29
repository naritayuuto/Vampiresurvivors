using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface ISkill
{
    SkillDef SkillId { get; }
    void SetUp();
    void LevelUp();
}

public enum SkillDef
{
    Invalid = 0,
    Bullet = 1,
    Knife = 2,
    Magic = 3,
    HolyWater = 4
}
