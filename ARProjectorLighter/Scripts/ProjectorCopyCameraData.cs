using UnityEngine;
using System.Collections;

public class ProjectorCopyCameraData : MonoBehaviour {

	public Camera targetCamera;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (1.0f);

		Projector _projector = gameObject.GetComponent<Projector> ();

		_projector.aspectRatio = targetCamera.aspect;
		_projector.fieldOfView = targetCamera.fieldOfView;
	}
	
	public float calculateCameraFOV()
    {
        Vector3 topCenter = targetCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height, 1.0f));
        Vector3 centerCenter = targetCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 1.0f));

        Vector3 frontVector = centerCenter - transform.position;
        Vector3 frontUpVector = topCenter - transform.position;
        float fovAngle = Vector3.Angle(frontVector, frontUpVector);

        return fovAngle * 2.0f;
    }
}
