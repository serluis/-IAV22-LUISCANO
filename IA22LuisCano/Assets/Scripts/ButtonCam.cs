using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;
using System.Collections;

public class ButtonCam : MonoBehaviour
{
    public Button b;
	public Camera mainCam;
	public GameObject fishCam;
	private bool deactivator = false;
	// Start is called before the first frame update
	void Start()
	{
		fishCam.gameObject.SetActive(false);
		
		Button btn = b.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		deactivator = !deactivator;
		Debug.Log("button!");
		mainCam.enabled = !deactivator;
		fishCam.gameObject.SetActive(deactivator);
	}
}
