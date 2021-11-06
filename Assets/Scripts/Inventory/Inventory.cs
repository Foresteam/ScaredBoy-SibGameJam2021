using System.Collections.Generic;
using UnityEngine;

	class Inventory : MonoBehaviour {
		[SerializeField] private Color _frameColorActive = Color.yellow;
		[SerializeField] private Color _frameColorInactive = Color.white;
		[SerializeField] private int _size = 3;
		public int size { get => _size; }
		public delegate void OnSelectedItemChangedHandler(object sender, WorldItem item);
		public event OnSelectedItemChangedHandler OnSelectedItemChange;

		private List<InventorySlot> _slots;
		private int _activeSlot;

		void Start() {
			_activeSlot = -1;
			_slots = new List<InventorySlot>(FindObjectOfType<GUICanvas>().GetComponentInChildren<GUIItems>().GetComponentsInChildren<InventorySlot>());
			_slots.Sort((InventorySlot a, InventorySlot b) => a.gameObject.name.CompareTo(b.gameObject.name));
			SelectItem(0);
		}
		public void SelectItem(int slot) {
			if (_activeSlot >= 0)
				_slots[_activeSlot].PaintFrame(_frameColorInactive);
			_slots[slot].PaintFrame(_frameColorActive);
			_activeSlot = slot;
			OnSelectedItemChange?.Invoke(this, _slots[_activeSlot].worldItem);
		}
		public void PickupItem(WorldItem worldItem, Vector2 playerPosition) {
			int slot;
			if (!_slots[_activeSlot].IsEmpty()) {
				for (slot = 0; slot < size; slot++)
					if (_slots[slot].IsEmpty())
						break;
				if (slot == size) {
					slot = _activeSlot;
					DropItem(playerPosition);
				}
			}
			else
				slot = _activeSlot;
			_slots[slot].DoPickup(worldItem);
			if (slot == _activeSlot)
				OnSelectedItemChange?.Invoke(this, worldItem);
		}
		public void DropItem(Vector2 playerPosition) {
			if (_slots[_activeSlot].IsEmpty())
				return;
			_slots[_activeSlot].DoDrop(playerPosition);
			OnSelectedItemChange?.Invoke(this, null);
		}
	}


