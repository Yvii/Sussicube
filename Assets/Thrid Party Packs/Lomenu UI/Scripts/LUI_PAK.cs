using UnityEngine;
//using UnityEngine.Experimental.Input;
using UnityEngine.InputSystem;

public class LUI_PAK : MonoBehaviour {

	[Header("VARIABLES")]
	public GameObject mainCanvas;
	public GameObject scriptObject;
	public Animator animatorComponent;
	public string animName;

	void Start ()
	{
		animatorComponent.GetComponent<Animator>();
	}

	void Update ()
	{
        // Press any Key currently only works with keyboard or Mouse
		if (Keyboard.current.anyKey.isPressed || Mouse.current.leftButton.isPressed) 
		{
			animatorComponent.Play (animName);
			mainCanvas.SetActive(true);
			Destroy (scriptObject);
		}
	}
}