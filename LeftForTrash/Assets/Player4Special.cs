using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Special : SpecialAttack {

    public SpriteRenderer item_get_sprite;
    public GameObject item_get;
    public List<GameObject> item_prefabs;

    public override void UseSpecialAttack()
    {
        int rand_num = Random.Range(0, item_prefabs.Count);

        item_get = item_prefabs[rand_num];
        item_get_sprite.sprite = item_get.GetComponent<SpriteRenderer>().sprite;
        item_get.GetComponent<ItemPickup>().UseItem(gameObject);
        base.UseSpecialAttack();
    }
}
