using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WorldItem : MonoBehaviour {
	[SerializeField] private GameObject _uiItem;
	public GameObject uiItem { get => _uiItem; }

	private void Start() {
		GetComponent<Rigidbody2D>().isKinematic = true;
	}
}
