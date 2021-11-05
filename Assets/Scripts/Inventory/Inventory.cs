using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory {
	class Inventory {
		private Color _frameColorActive, _frameColorInactive = Color.white;

		private int _size;
		private Item[] _items;
		private int _activeSlot;

		public Inventory(int size, Color frameColorActive, Color frameColorInactive, GameObject uiItemPrefab) {
			_frameColorActive = frameColorActive;
			_frameColorInactive = frameColorInactive;
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