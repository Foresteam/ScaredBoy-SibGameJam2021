using UnityEngine;

public class NPC : AInterractor {
    public DialogWindow dialogWindow;
    private NPCInterractable _interractable;

    void Start() {
        _interractable = new NPCInterractable(this);
    }

    public override void Interract() => _interractable.Interract();
}