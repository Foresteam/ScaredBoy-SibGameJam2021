using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Inventory))]
public class PlayerControl : MonoBehaviour {
	[SerializeField] private Text _hint;
	[SerializeField] private float _speed;
	[SerializeField] private SpriteRenderer _playerSprite;
	public string textWhenPickUp, textWhenInterract;

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
		if (item != null && item.TryGetComponent<FlashlightItem>(out _))
			_flashlight.On();
		else
			_flashlight.Off();
	}

	void Update() {
		AInterractor aInterractor = _pickuper.toInterract;
		if (aInterractor != null && aInterractor.gameObject.activeInHierarchy)
			if (aInterractor is WorldItem)
				_hint.text = textWhenPickUp;
			else
				_hint.text = textWhenInterract;
		else
			_hint.text = "";

		if (Input.GetKeyDown(KeyCode.E) && aInterractor != null && aInterractor.gameObject.activeInHierarchy) {
			if (aInterractor is WorldItem)
				_inventory.PickupItem((WorldItem)aInterractor, new Vector2(transform.position.x, transform.position.y));
			else
				aInterractor.Interract();
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
		gameObject.transform.position += Direction * _speed * Time.deltaTime;
		_playerSprite.flipX = Direction.x < 0;
	}
}
