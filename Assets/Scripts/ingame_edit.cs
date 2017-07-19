using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingame_edit : MonoBehaviour {

	public GameObject selectedobj;
	public Text selectedname;
	public Text lookatname;
	public GameObject tutorial;
	public float moveamt = 0.1f;
	Text text1;
	Text text2;
	string string1;
	string string2;
	bool edit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update() {
		selectedname.text = selectedobj.transform.name;
		if (edit == false && Input.GetKeyDown (KeyCode.T)) {
			edit = true;
			print ("edit is now true");
		}
		else if (edit == true) {
			tutorial.SetActive (true);
			print ("Fuck me");
			if (Input.GetKeyDown (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y+moveamt,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad2)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y-moveamt,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad4)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x+moveamt, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad6)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x-moveamt, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.T)) {
				tutorial.SetActive (false);
				edit = false;
			}
		} 
	}
	void FixedUpdate () {
		RaycastHit hit;
		Vector3 position = transform.TransformDirection (Vector3.forward);

		if (Physics.Raycast(transform.position, position, out hit))
			{
			lookatname.text = hit.transform.name;
			if (Input.GetMouseButtonDown(0)) {
				selectedobj = hit.collider.gameObject;
			}
			if (Input.GetMouseButtonDown (1)) {
				Instantiate (selectedobj, new Vector3(hit.point.x,hit.point.y,hit.point.z), Quaternion.identity);
			}
			}
		
	}
}
