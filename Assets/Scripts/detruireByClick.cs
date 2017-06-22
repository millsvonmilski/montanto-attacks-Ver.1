using UnityEngine;
using System.Collections;

public class detruireByClick : MonoBehaviour {

	private GameObject asteroides;
	public GameObject explosionChute;
	private enemiController enemiControl;
	public GameObject explosionClick;

	private GameObject clone;


	public int scoreValue;


	void Start () {
	
		asteroides = GameObject.FindGameObjectWithTag ("asteroid");


		// INTERSANTE LO QUE HAGO ABAJO, REPASAR

		GameObject enemiControllerObject = GameObject.FindWithTag ("enemi");  // Creo instancia del enemiController.

		if (enemiControllerObject != null) {
				
			enemiControl = enemiControllerObject.GetComponent<enemiController> ();

		} 

		if (enemiControl == null) {
			Debug.Log ("NO PUEDO ENCONTRAR EL 'enemiController' script");
		}


	}



	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "sol") {

			Instantiate (explosionChute, transform.position, transform.rotation);

			enemiControl.playSound("sol");

			Destroy (asteroides.gameObject);
			Destroy (gameObject);
		} 

		else if (collision.gameObject.tag == "enemi" || collision.gameObject.tag == "fond") {

			return;

		} else {

			// CODIGO EN EL QUE DESTRUYO LOS ELEMENTOS DE LA CIUDAD, CONTROLARE LAS VIDAS 
			// DEL USUARIO Y LLAMARE LA FUNCION GAMEOVER CUANDO HAGA FALTA

			Instantiate (explosionChute, transform.position, transform.rotation);
			enemiControl.playSound("ciudad");


			Destroy (collision.gameObject);
			Destroy (gameObject);
			enemiControl.substractScore(10,1); // SIEMPRE RESTO 10 CUANDO SE DESTRUYE UN ELEMENTO
		}
	}
		



	void FixedUpdate () {
		
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
					
				//GameObject clone = GameObject.Find(hit.transform.GetInstanceID ().ToString ());
				//clone.name = hit.transform.GetInstanceID ().ToString ();

				if (hit.transform.tag == "asteroid") {
				
					Instantiate (explosionClick, hit.transform.position, hit.transform.rotation);

					enemiControl.playSound("clique");
					enemiControl.AddScore (scoreValue); // Asigno un nuevo valor de score.

					Destroy (this);
					Destroy (gameObject);

				} else {
					
					return;
				}
			}

		}

}
}
		