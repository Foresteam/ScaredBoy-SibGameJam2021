using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory {
	class Inventory : MonoBehaviour {
		[SerializeField] private Color _frameColorActive;
		[SerializeField] private Color _frameColorInactive = Color.white;
		[SerializeField] private int _size;

		private Item[] _items;
		private int _activeSlot;

		void Start() {
			_items = new Item[_size];
		}
		public void SelectItem(int slot) {
			_items[_activeSlot].PaintFrame(_frameColorInactive);
			_items[slot].PaintFrame(_frameColorActive);
			_activeSlot = slot;
		}
		public void PickUpItem(WorldItem worldItem, Vector2 playerPosition) {
			int slot = 0;
			for (; slot < _size; slot++)
				if (_items[slot] == null)
					break;
			if (slot == _size) {
				slot = _activeSlot;
				DropItem(slot, playerPosition);
			}
			_items[slot] = new Item(worldItem, slot);
		}
		public void DropItem(int slot, Vector2 playerPosition) {
			_items[slot].DoDrop(playerPosition);
			_items[slot] = null;
		}
	}
}