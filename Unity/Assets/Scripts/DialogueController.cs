using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
	public Text speakerText;
	public Text messageText;
	public Image icon;
	public GameObject dialogueBox;

	private bool active = false;
	private bool done;

	public bool Active {
		get {
			return active;
		}
		set {
			active = value;
		}
	}

	public void speak(string message, string speaker) {
		done = false;
		speakerText.text = speaker;
		messageText.text = "";
		dialogueBox.SetActive (true);

		StartCoroutine (speak (message.ToCharArray ()));
	}

	public void speak(string message, string speaker, Sprite s) {
		done = false;
		speakerText.text = speaker;
		messageText.text = "";
		dialogueBox.SetActive (true);
		icon.sprite = s;

		StartCoroutine (speak (message.ToCharArray ()));
	}

	IEnumerator speak(char[] message) {
		active = true;
		bool skip = false;
		foreach (char c in message) {
			if (!skip) {
				yield return new WaitForSeconds (0.02f);
			}
			messageText.text += c;
			if (Input.GetMouseButtonDown (1)) {
				skip = true;
			}
		}
		messageText.text += "\nPress any key to continue...";
		done = true;
	}

	void Update() {
		if (done && Input.anyKeyDown) {
			active = false;
			dialogueBox.SetActive (false);
			icon.sprite = null;
		}
	}
}