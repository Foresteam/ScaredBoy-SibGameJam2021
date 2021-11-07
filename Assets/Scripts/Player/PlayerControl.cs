using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Inventory))]
public class PlayerControl : MonoBehaviour {
	[SerializeField] private Text _hint;
	[SerializeField] private float _speed;
	[SerializeField] private GameObject _playerSprite;
	public string textWhenPickUp, textWhenInterract;
	public Transform ObjectsInHand;
	public bool locked { get; set; }

	private Inventory _inventory;
	private PlayerInterractor _interractor;
	public Flashlight flashlight;

	public GameObject WalikingSprite;
	public GameObject StaySprite;

	void Start() {
		_inventory = GetComponent<Inventory>();
		_interractor = GetComponentInChildren<PlayerInterractor>();
		flashlight = GetComponentInChildren<Flashlight>();

		_inventory.OnSelectedItemChange += OnSelectedItemChanged;
		locked = false;
	}

	void OnSelectedItemChanged(object sender, WorldItem item) {
		if ((UnityEngine.Object)sender != _inventory)
			return;
		FlashlightItem _;
		if (item != null && item.TryGetComponent<FlashlightItem>(out _))
			flashlight.On();
		else
			flashlight.Off();
	}

	void Update() {
		AInterractor aInterractor = _interractor.toInterract;
		if (aInterractor != null && aInterractor.gameObject.activeInHierarchy)
			if (aInterractor is WorldItem)
				_hint.text = textWhenPickUp;
			else if (aInterractor is NPC)
				_hint.text = "Поговорить";
			else
				_hint.text = textWhenInterract;
		else
			_hint.text = "";
		
		if (locked)
			return;

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
	void FixedUpdate() {
		if (locked)
			return;
		if (Input.GetButton("Horizontal"))
		{
			Walk();
			WalikingSprite.SetActive(true);
			StaySprite.SetActive(false);
		}
		else
        {
			WalikingSprite.SetActive(false);
			StaySprite.SetActive(true);
		}
	}
	public void Walk() {
		Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		gameObject.transform.position += Direction * _speed * Time.deltaTime;
		if (Direction.x < 0)
		{
			ObjectsInHand.localScale = new Vector3(-1, 1, 1);
			_playerSprite.transform.localScale = new Vector3(-1,1,1);
		}
		else
		{
			ObjectsInHand.localScale = new Vector3(1, 1, 1);
			_playerSprite.transform.localScale = new Vector3(1, 1, 1);
		}
	}
}
