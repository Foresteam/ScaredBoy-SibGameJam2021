using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterractor : MonoBehaviour {
	public AInterractor toInterract { get; private set; }
	private List<AInterractor> _toInterract;

    private void Start() {
		toInterract = null;
		_toInterract = new List<AInterractor>();
	}

	private void RefindNearest() {
        _toInterract.Sort((AInterractor a, AInterractor b) => {
            if (Vector3.Distance(a.transform.position, transform.parent.position) >= Vector3.Distance(b.transform.position, transform.parent.position) && b.gameObject.activeInHierarchy)
                return -1;
            else
                return 1;
        });
        toInterract = _toInterract[0];
	}
	private void TryResetNearest() {
        if (_toInterract.Count > 0)
            toInterract = _toInterract[0];
        else
            toInterract = null;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		AInterractor aInterractor;
		if (!collision.TryGetComponent<AInterractor>(out aInterractor))
			return;
		if (!_toInterract.Contains(aInterractor))
			_toInterract.Add(aInterractor);
		RefindNearest();
	}
	private void OnTriggerExit2D(Collider2D collision) {
		AInterractor aInterractor;
		if (!collision.TryGetComponent<AInterractor>(out aInterractor))
			return;
		_toInterract.Remove(aInterractor);
		TryResetNearest();
	}
}