using UnityEngine;

public abstract class AInterractor : MonoBehaviour {
    [SerializeField] protected GameObject _object = null;
    public virtual void Interract() { } // returns false if overrides picking up behavior
}