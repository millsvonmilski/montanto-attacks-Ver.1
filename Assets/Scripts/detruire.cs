using UnityEngine;
using System.Collections;

public class detruire : MonoBehaviour {


	private enemiController enemiControl;

	// Use this for initialization
	void Start () {
		// INTERSANTE LO QUE HAGO ABAJO, REPASAR

		GameObject enemiControllerObject = GameObject.FindWithTag ("enemi");  // Creo instancia del enemiController.

		if (enemiControllerObject != null) {

			enemiControl = enemiControllerObject.GetComponent<enemiController> ();

		} 

		if (enemiControl == null) {
			Debug.Log ("NO PUEDO ENCONTRAR EL 'enemiController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {

				//GameObject clone = GameObject.Find(hit.transform.GetInstanceID ().ToString ());
				//clone.name = hit.transform.GetInstanceID ().ToString ();

				if (hit.transform.tag == "asteroid") {

					//Instantiate (explosionClick, hit.transform.position, hit.transform.rotation);

					enemiControl.playSound("clique");
					//enemiControl.AddScore (scoreValue); // Asigno un nuevo valor de score.

					//Destroy (hit);
					//Destroy (gameObject);

				} else {

					return;
				}
			}

		}

	}

}
