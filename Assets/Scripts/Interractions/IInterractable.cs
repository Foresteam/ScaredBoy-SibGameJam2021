using UnityEngine;
public interface IInterractable {
    void Interract(params object[] data); // returns true if overrides picking up behaviour
}