using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuper : MonoBehaviour {
	public WorldItem toBePickedUp { get; private set; }
	private List<WorldItem> _canBePickedUp;

    private void Start() {
		toBePickedUp = null;
		_canBePickedUp = new List<WorldItem>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		WorldItem worldItem;
		if (!collision.TryGetComponent<WorldItem>(out worldItem))
			return;
		if (!_canBePickedUp.Contains(worldItem))
			_canBePickedUp.Add(worldItem);
		_canBePickedUp.Sort((WorldItem a, WorldItem b) => {
			if (Vector3.Distance(a.transform.position, transform.parent.position) >= Vector3.Distance(b.transform.position, transform.parent.position))
				return -1;
			else
				return 1;
		});
		toBePickedUp = _canBePickedUp[0];
	}
	private void OnTriggerExit2D(Collider2D collision) {
		WorldItem worldItem;
		if (!collision.TryGetComponent<WorldItem>(out worldItem))
			return;
		_canBePickedUp.Remove(worldItem);
		if (_canBePickedUp.Count > 0)
			toBePickedUp = _canBePickedUp[0];
		else
			toBePickedUp = null;
	}
}