using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
	public Text speakerText;
	public Text messageText;
	public GameObject dialogueBox;

	private bool active = false;

	public bool Active {
		get {
			return active;
		}
		set {
			active = value;
		}
	}
}