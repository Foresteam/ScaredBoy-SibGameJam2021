using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public WordItem WorldRep { get; private set; }
    public Sprite UIRep { get; private set; }

    public Item(WordItem worldRepresentation) {
        WorldRep = worldRepresentation;
        UIRep = worldRepresentation.uiRepresentationPrefab;
    }
}
