using UnityEngine;
using System.Collections;

public class detruireLimits : MonoBehaviour {

	void OnTriggerExit(Collider other) {

		Destroy (other.gameObject);
	}
}
