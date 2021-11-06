using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WorldItem : MonoBehaviour {
	private void Start() {
		GetComponent<Rigidbody2D>().isKinematic = true;
	}
}
