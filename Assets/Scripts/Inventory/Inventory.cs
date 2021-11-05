using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory {
	class Inventory : MonoBehaviour {
		[SerializeField] private Color _frameColorActive = Color.yellow;
		[SerializeField] private Color _frameColorInactive = Color.white;
		[SerializeField] private int _size = 3;
		public int size { get => _size; }

		private List<Slot> _slots;
		private int _activeSlot;

		void Start() {
			_activeSlot = -1;
			_slots = new List<Slot>(FindObjectsOfType<Slot>());
			_slots.Reverse();
			SelectItem(0);
		}
		public void SelectItem(int slot) {
			if (_activeSlot >= 0)
				_slots[_activeSlot].PaintFrame(_frameColorInactive);
			_slots[slot].PaintFrame(_frameColorActive);
			_activeSlot = slot;
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
		}
		public void DropItem(Vector2 playerPosition) {
			if (_slots[_activeSlot].IsEmpty())
				return;
			_slots[_activeSlot].DoDrop(playerPosition);
		}
	}
}