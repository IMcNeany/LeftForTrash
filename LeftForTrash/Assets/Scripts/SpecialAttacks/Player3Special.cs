using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Special : SpecialAttack
{


    public override void UseSpecialAttack()
    {
        combat.RangedAttack(1);
        base.UseSpecialAttack();
    }
}
