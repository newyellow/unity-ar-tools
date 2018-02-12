using UnityEngine;
using System.Collections;
using Vuforia;

public class VuforiaFocusMode : MonoBehaviour {

	public CameraDevice.FocusMode focusMode;
	bool focusResult = false;

	// Use this for initialization
	IEnumerator Start () {

		// wait for camera setup
		while (!VuforiaARController.Instance.HasStarted) {
			yield return null;
		}

		Debug.Log ("GOGO");

		focusResult = Vuforia.CameraDevice.Instance.SetFocusMode (focusMode);
	}

	void OnGUI () {
	}
}
