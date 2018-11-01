using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Special : SpecialAttack {

    public PlayerCombat combat;

    //player 1 special is to throw an explosive projectile
    public override void UseSpecialAttack()
    {
        combat.RangedAttack();
        current_delay = special_delay;
    }
}
