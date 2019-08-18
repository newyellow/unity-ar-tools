using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EasyAR3Setup : MonoBehaviour {

    Camera _bgCam;

	public Material projectorMat;

	public LayerMask projectorIgnoreLayerMask;
    public LayerMask arCameraCullingMask = 1;

    public RenderTextureSizeSetting renderTextureSize = RenderTextureSizeSetting.Full;

	// Use this for initialization
	void Start () {

        _bgCam = gameObject.GetComponent<Camera>();
        _bgCam.cullingMask = 0;

		Setup();
	}

	void Setup () {

		// add projector
		GameObject projectorObj = new GameObject("_Projector");
		projectorObj.transform.parent = transform;
		projectorObj.transform.localPosition = Vector3.zero;
		projectorObj.transform.localRotation = Quaternion.identity;

		Projector projectorScript = projectorObj.AddComponent<Projector> ();
		projectorScript.material = projectorMat;
		projectorScript.ignoreLayers = projectorIgnoreLayerMask;

		ProjectorCopyCameraData projectorCamAdjustScript = projectorObj.AddComponent<ProjectorCopyCameraData> ();
		projectorCamAdjustScript.targetCamera = _bgCam;

        // setup BG cam
		RenderTextureToProjector RTtPScript = _bgCam.gameObject.AddComponent<RenderTextureToProjector> ();
		RTtPScript._projector = projectorScript;
        RTtPScript.SetupTexture(renderTextureSize);


		// setup AR cam
		GameObject arCam = new GameObject("_AR Cam");
		arCam.transform.parent = transform;
		arCam.transform.localPosition = Vector3.zero;
		arCam.transform.localRotation = Quaternion.identity;

		Camera arCamera = arCam.AddComponent<Camera> ();
		arCamera.farClipPlane = 2500.0f;
		arCamera.nearClipPlane = 0.01f;
		arCamera.clearFlags = CameraClearFlags.SolidColor;
        arCamera.cullingMask = arCameraCullingMask;

		CopyCameraData cameraAdjustScript = arCam.AddComponent<CopyCameraData> ();
		cameraAdjustScript.targetCamera = _bgCam;

	}
}
