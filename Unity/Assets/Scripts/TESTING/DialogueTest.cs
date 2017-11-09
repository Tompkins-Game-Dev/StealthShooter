using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTest : MonoBehaviour {
	public InputField input;
	DialogueController d;

	void Start() {
		d = FindObjectOfType<DialogueController> ();
	}

	public void updateText() {
		if (!d.Active)
			d.speak (input.text, "Speaker " + Random.Range (1, 10));
	}
}
