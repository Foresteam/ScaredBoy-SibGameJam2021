using UnityEngine;

public class Switch : AInterractor {
    [SerializeField] private Sprite _spriteActive;
    [SerializeField] private Sprite _spriteInactive;
    [SerializeField] private bool _state = false;
    [SerializeField] private bool _onePress = false;
    private bool _pressed;
    void Start() {
        _pressed = false;
        ApplyState();
    }
    void ApplyState() {
        if (_state)
            GetComponent<SpriteRenderer>().sprite = _spriteActive;
        else
            GetComponent<SpriteRenderer>().sprite = _spriteInactive;
        _interratableObject.GetComponent<IInterractable>().Interract(_state);
    }
    public override void Interract() {
        if (!_pressed)
            _pressed = true;
        else if (_onePress)
            return;

        _state = !_state;
        ApplyState();
    }
}