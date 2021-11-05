using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public WorldItem WorldRep { get; private set; }
    public Sprite UIRep { get; private set; }
    private Sprite _uiSprite;

    public Item(WorldItem worldRepresentation) {
        WorldRep = worldRepresentation;
        _uiSprite = worldRepresentation.GetComponent<SpriteRenderer>().sprite;
    }
    public void DoPickUp() {
        WorldRep.gameObject.SetActive(false);
    }
    public void DoDrop(Vector2 playerPosition) {
        WorldRep.transform.position = playerPosition + new Vector2(0, 1);
        WorldRep.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 5, Random.value * 5);
        WorldRep.gameObject.SetActive(true);
    }
}
