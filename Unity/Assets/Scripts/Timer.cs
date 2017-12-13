using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public bool count; // Just for testing

    private Text text;
	private double time;
	private bool pause;

    // Use this for initialization
    void Start() {
        text = GetComponent <Text> ();
    }

    // Update is called once per frame
    void Update() {
        if (count) {
            time += Math.Round ((double) Time.deltaTime, 2); // Rounding point errors, but I forgot how to fix
            text.text = time.ToString ();
        }
    }

	public void ResetTimer () {
		count = false;
		time = 0f;
	}

    public double GetTime()
    { return time; }

    public void SetPause (bool new_pause) {
        pause = new_pause;

        if (pause) {
            count = false;
            /* Consider using a public static "can_move" bool on all NPCs and the player
		     * Will need to include a check for "can_move" in all movement scripts
			 * Consider a master controller script that only activates movement scripts if "can_move" is true, attached to all GameObjects
			 */
        }
    }
}
