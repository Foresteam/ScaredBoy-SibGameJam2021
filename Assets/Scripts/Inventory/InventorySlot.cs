using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	[SerializeField] GameObject _uiItemPrefab;
	private GameObject _uiItem;
	private WorldItem _worldItem;
	private Sprite _uiSprite;

	public WorldItem worldItem { get => _worldItem; }

	private void Start() {
		_uiItem = null;
		_worldItem = null;
		_uiSprite = null;
	}

	public void DoPickup(WorldItem worldItem) {
		_worldItem = worldItem;
		_uiSprite = _worldItem.GetComponent<SpriteRenderer>().sprite;

		_uiItem = GameObject.Instantiate(_uiItemPrefab, transform);
		_uiItem.GetComponent<Image>().sprite = _uiSprite;
		var rt = _uiItem.GetComponent<RectTransform>();
		rt.sizeDelta = GetComponent<RectTransform>().sizeDelta;

		_worldItem.gameObject.SetActive(false); // deactivate the world representation, leaving the UI one only
	}

	public void DoDrop(Vector2 playerPosition) {
		_worldItem.gameObject.SetActive(true);
		_worldItem.GetComponent<Rigidbody2D>().isKinematic = false;
		_worldItem.transform.position = playerPosition + new Vector2(0, 1);
		_worldItem.transform.rotation = new Quaternion();
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