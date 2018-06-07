using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		Destroy (gameObject);
	}

}
