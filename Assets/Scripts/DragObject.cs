using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour, DragObjectHandler {

	public Material InactiveMaterial;
	public Material ActiveMaterial;

	private bool IsActive;
	private GameObject Reticle;

	// Use this for initialization
	void Start () {
		IsActive = false;
		GetComponent<Renderer>().material = InactiveMaterial;
		Reticle = GameObject.Find ("DragObjectReticlePointer");
	}
	
	// Update is called once per frame
	void Update () {
		if (IsActive) {
			Ray ray = new Ray (Reticle.transform.position, Reticle.transform.forward);
			transform.position = ray.GetPoint (4);
		}
	}

	public void HandlePointerClickDown() {
		IsActive = true;
		GetComponent<Renderer>().material = ActiveMaterial;
	}

	public void HandlePointerClickUp() {
		IsActive = false;
		GetComponent<Renderer>().material = InactiveMaterial;
	}
}
