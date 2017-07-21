using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ingame_edit : MonoBehaviour {

	public GameObject selectedobj;
	public Text selectedname;
	public Text lookatname;
	public GameObject tutorial;
	public float moveamt = 0.1f;
	public float rotateamt = 0.1f;
	public InputField prenam;
	public GameObject prenamobj;
	string prefabname;
	Text text1;
	Text text2;
	string string1;
	string string2;
	bool edit;
	bool mouse = false;

	// Use this for initialization
	void Start () {
		prenam.DeactivateInputField ();
	}
	
	// Update is called once per frame
	void Update() {
		selectedname.text = selectedobj.transform.name;
		//adds rigidbody to gameobject
		if (Input.GetKeyDown (KeyCode.P)) {
			Rigidbody rb = selectedobj.AddComponent<Rigidbody> () as Rigidbody;
		}
		//creates new prefab
		if (Input.GetKeyDown (KeyCode.C)) {
			Cursor.lockState = CursorLockMode.None;
			mouse = true;
			prenamobj.SetActive (true);
			prefabname = prenam.text;
			if (Input.GetKeyDown (KeyCode.Tab)) {
				prenamobj.SetActive (false);
				//Cursor.lockState = CursorLockMode.Locked;
				//Cursor.visible = false;
				mouse = false;
			}
		}
		if (mouse == true) {
			//Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		//enables ingame editor
		if (edit == false && Input.GetKeyDown (KeyCode.T)) {
			edit = true;
		}
		//All editor controls for movement and rotation
		else if (edit == true) {
			tutorial.SetActive (true);
			if (Input.GetKey (KeyCode.KeypadPlus)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y+moveamt,selectedobj.transform.position.z);
			}
			if (Input.GetKey (KeyCode.KeypadMinus)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y-moveamt,selectedobj.transform.position.z);
			}
			if (Input.GetKey (KeyCode.Keypad4)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x+moveamt, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKey (KeyCode.Keypad6)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x-moveamt, selectedobj.transform.position.y,selectedobj.transform.position.z);
			}
			if (Input.GetKey (KeyCode.Keypad8)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z+moveamt);
			}
			if (Input.GetKey (KeyCode.Keypad5)){
				selectedobj.transform.position = new Vector3(selectedobj.transform.position.x, selectedobj.transform.position.y,selectedobj.transform.position.z-moveamt);
			}
			if (Input.GetKey (KeyCode.Keypad7)){
				selectedobj.transform.eulerAngles = new Vector3(selectedobj.transform.eulerAngles.x+rotateamt, selectedobj.transform.eulerAngles.y,selectedobj.transform.eulerAngles.z);
			}
			if (Input.GetKey (KeyCode.Keypad9)){
				selectedobj.transform.eulerAngles = new Vector3(selectedobj.transform.eulerAngles.x, selectedobj.transform.eulerAngles.y,selectedobj.transform.eulerAngles.z+rotateamt);
			}
			if (Input.GetKey (KeyCode.KeypadDivide)){
				selectedobj.transform.eulerAngles = new Vector3(selectedobj.transform.eulerAngles.x, selectedobj.transform.eulerAngles.y+rotateamt,selectedobj.transform.eulerAngles.z);
			}
			if (Input.GetKey (KeyCode.Tab) && edit == true) {
				tutorial.SetActive (false);
				edit = false;
			}
		} 
	}

	//Allows player to select and spawn selected objects
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

	//Creates new prefab from selected object in editor
	public void CreatePrefab(){
		Object newprefab = PrefabUtility.CreateEmptyPrefab ("Assets/Prefabs/" + prefabname + ".prefab");
		PrefabUtility.ReplacePrefab (selectedobj, newprefab, ReplacePrefabOptions.ConnectToPrefab);
		print ("Prefab Created");
	}
}
