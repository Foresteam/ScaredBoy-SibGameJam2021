using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Inventory))]
public class PlayerControl : MonoBehaviour {
	public float Speed;
	public SpriteRenderer PlayerSprite;
	private Inventory _inventory;
	private Pickuper _pickuper;
	private Flashlight _flashlight;

	void Start() {
		_inventory = GetComponent<Inventory>();
		_pickuper = GetComponentInChildren<Pickuper>();
		_flashlight = GetComponentInChildren<Flashlight>();

		_inventory.OnSelectedItemChange += OnSelectedItemChanged;
	}

	void OnSelectedItemChanged(object sender, WorldItem item) {
		if ((UnityEngine.Object)sender != _inventory)
			return;
		FlashlightItem _;
		Debug.Log(_flashlight.gameObject);
		if (item != null && item.TryGetComponent<FlashlightItem>(out _))
			_flashlight.On();
		else
			_flashlight.Off();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.E)) {
			WorldItem worldItem = _pickuper.toBePickedUp;
			if (worldItem != null && worldItem.gameObject.activeInHierarchy)
				_inventory.PickupItem(worldItem, new Vector2(transform.position.x, transform.position.y));
		}
		if (Input.GetKeyDown(KeyCode.Q))
			_inventory.DropItem(transform.position);
		for (int slot = 0; slot < _inventory.size; slot++)
			if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), "Alpha" + (slot + 1)))) // black magic
				_inventory.SelectItem(slot);
	}
	private void FixedUpdate() {
		if (Input.GetButton("Horizontal"))
			Run();
	}
	public void Run() {
		Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		gameObject.transform.position += Direction * Speed;
		PlayerSprite.flipX = Direction.x < 0;
	}
}
