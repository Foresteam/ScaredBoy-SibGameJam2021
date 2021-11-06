using UnityEngine;

public class NPCInterractable : IInterractable {
    NPC _npc;
    public NPCInterractable(NPC npc) {
        _npc = npc;
    }
    public void Interract(params object[] data) {
        _npc.dialogWindow.Show();
    }
}