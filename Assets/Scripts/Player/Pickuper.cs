using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuper : MonoBehaviour {
	public AInterractor toInterract { get; private set; }
	private List<AInterractor> _toInterract;

    private void Start() {
		toInterract = null;
		_toInterract = new List<AInterractor>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		AInterractor aInterractor;
		if (!collision.TryGetComponent<AInterractor>(out aInterractor))
			return;
		if (!_toInterract.Contains(aInterractor))
			_toInterract.Add(aInterractor);
		_toInterract.Sort((AInterractor a, AInterractor b) => {
			if (Vector3.Distance(a.transform.position, transform.parent.position) >= Vector3.Distance(b.transform.position, transform.parent.position))
				return -1;
			else
				return 1;
		});
		toInterract = _toInterract[0];
	}
	private void OnTriggerExit2D(Collider2D collision) {
		AInterractor aInterractor;
		if (!collision.TryGetComponent<AInterractor>(out aInterractor))
			return;
		_toInterract.Remove(aInterractor);
		if (_toInterract.Count > 0)
			toInterract = _toInterract[0];
		else
			toInterract = null;
	}
}