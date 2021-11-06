using UnityEngine;

public abstract class AInterractor : MonoBehaviour {
    [SerializeField] protected GameObject _interratableObject = null;
    public virtual void Interract() {
        if (_interratableObject != null)
            _interratableObject.GetComponent<IInterractable>().Interract();
    } // returns false if overrides picking up behavior
}