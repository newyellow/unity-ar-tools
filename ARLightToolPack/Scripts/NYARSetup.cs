using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class NYARSetup : MonoBehaviour {

	public Camera BGCam;
	public Material projectorMat;

	public string bgLayerName;
	public string lightLayerName;

	public LayerMask projectorIgnoreLayerMask;
	public LayerMask bgCamLayerMask;

	// Use this for initialization
	IEnumerator Start () {

		// wait for vuforia camera setup
		while (!VuforiaARController.Instance.HasStarted) {
			yield return null;
		}

		Setup();
	}

	void Setup () {

		// add projector
		GameObject projectorObj = new GameObject("_Projector");
		projectorObj.transform.parent = BGCam.transform;
		projectorObj.transform.localPosition = Vector3.zero;
		projectorObj.transform.localRotation = Quaternion.identity;

		Projector projectorScript = projectorObj.AddComponent<Projector> ();
		projectorScript.material = projectorMat;
		projectorScript.ignoreLayers = projectorIgnoreLayerMask;

		ProjectorCopyCameraData projectorCamAdjustScript = projectorObj.AddComponent<ProjectorCopyCameraData> ();
		projectorCamAdjustScript.targetCamera = BGCam;

		// setup BG cam
		BGCam.cullingMask = bgCamLayerMask;
		RenderTextureToProjector RTtPScript = BGCam.gameObject.AddComponent<RenderTextureToProjector> ();
		RTtPScript._projector = projectorScript;


		// setup AR cam
		GameObject arCam = new GameObject("_AR Cam");
		arCam.transform.parent = BGCam.transform;
		arCam.transform.localPosition = Vector3.zero;
		arCam.transform.localRotation = Quaternion.identity;

		Camera arCamera = arCam.AddComponent<Camera> ();
		arCamera.farClipPlane = 2000.0f;
		arCamera.nearClipPlane = 0.01f;
		arCamera.clearFlags = CameraClearFlags.Color;

		CopyCameraData cameraAdjustScript = arCam.AddComponent<CopyCameraData> ();
		cameraAdjustScript.targetCamera = BGCam;

	}

	// Update is called once per frame
	void Update () {
		
	}
}
