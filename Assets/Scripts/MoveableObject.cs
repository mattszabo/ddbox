using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

	public Material InactiveMaterial;
	public Material ActiveMaterial;
	public Material HighlightedMaterial;

	private bool isActive;
	private bool isThrown;
	private bool isHighlighted;

	private GameObject laser;
	private Vector3 objectLastPosition;
	private Vector3 objectVelocity;

	// Use this for initialization
	void Start () {
		isActive = false;
		isThrown = false;
		isHighlighted = false;
		GetComponent<Renderer>().material = InactiveMaterial;
		laser = GameObject.Find ("Laser");
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			FollowPointer ();
			CalculateObjectVelocity ();
		}
		if (isThrown) {
			ThrowObject ();
		}
		if (GvrController.ClickButtonDown && isHighlighted) {
			ActivateObject();
		}
		if (GvrController.ClickButtonUp) {
			InactivateObject ();
			CheckForThrownObject ();
		}
	}

	public void HighlightObject() {
		setColorToHighlighted ();
		isHighlighted = true;
	}

	public void ActivateObject() {
		isActive = true;
		setColourToActive ();
	}

	public void InactivateObject() {
		setColourToInactive ();
		isHighlighted = false;
		isActive = false;
	}

	public void FollowPointer() {
		Ray ray = new Ray (laser.transform.position - new Vector3(-.25f,.5f,0f), laser.transform.forward);
		transform.position = ray.GetPoint (6.5f);
	}

	public void CheckForThrownObject() {
		if (transform.position.y > 0.5) {
			isThrown = true;
		}
	}

	public void CalculateObjectVelocity() {
		objectVelocity = (transform.position - objectLastPosition) / Time.fixedDeltaTime;
		objectLastPosition = transform.position;
	}

	public void ThrowObject() {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (objectVelocity.x, objectVelocity.y, objectVelocity.z, ForceMode.Force);

		isThrown = false;
	}

	public void setColorToHighlighted() {
		GetComponent<Renderer> ().material = HighlightedMaterial;
	}

	public void setColourToInactive() {
		GetComponent<Renderer>().material = InactiveMaterial;
	}

	public void setColourToActive() {
		GetComponent<Renderer>().material = ActiveMaterial;
	}
}
