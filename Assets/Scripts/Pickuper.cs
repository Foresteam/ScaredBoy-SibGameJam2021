using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Inventory;

public class Pickuper : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        WorldItem worldItem;
        if (!collision.TryGetComponent<WorldItem>(out worldItem))
            return;
        GetComponentInParent<Inventory>().PickUpItem(worldItem, transform.parent.position);
    }
}
