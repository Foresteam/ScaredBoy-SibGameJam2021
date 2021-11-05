using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory {
	public class Slot : MonoBehaviour {
		private GameObject _uiItem;
		private WorldItem _worldItem;
		private Sprite _uiSprite;

        private void Start() {
			_uiItem = null;
			_worldItem = null;
			_uiSprite = null;
        }

        public void DoPickup(WorldItem worldItem) {
			_worldItem = worldItem;
			_uiSprite = _worldItem.GetComponent<SpriteRenderer>().sprite;

			_uiItem = GameObject.Instantiate(_worldItem.uiItem, transform);
			_uiItem.GetComponent<Image>().sprite = _uiSprite;

			_worldItem.gameObject.SetActive(false); // deactivate the world representation, leaving the UI one only
		}

		public void DoDrop(Vector2 playerPosition) {
			_worldItem.gameObject.SetActive(true);
			_worldItem.GetComponent<Rigidbody2D>().isKinematic = false;
			_worldItem.transform.position = playerPosition + new Vector2(0, 1);
			_worldItem.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
			Object.Destroy(_uiItem);

			_uiItem = null;
			_worldItem = null;
			_uiSprite = null;
		}
		public void PaintFrame(Color color) {
			GetComponent<Image>().color = color;
		}
		public bool IsEmpty() => _worldItem == null || _worldItem == null || _uiSprite == null;
	}
}