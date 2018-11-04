using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Special : SpecialAttack {


    //player 1 special is to throw an explosive projectile
    public override void UseSpecialAttack()
    {
        combat.RangedAttack(0);
        base.UseSpecialAttack();
    }
}
