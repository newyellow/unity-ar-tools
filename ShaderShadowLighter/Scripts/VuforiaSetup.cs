using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaSetup : MonoBehaviour
{
    public string bgLayerName;
    public LayerMask bgCamCulling;

    Camera _cam;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            if (VuforiaRuntime.Instance.InitializationState == VuforiaRuntime.InitState.INITIALIZED)
                break;

            yield return null;
        }

        // wait till there is BackgroundPlane generated
        while(transform.Find("BackgroundPlane") == null)
        {
            yield return null;
        }

        GameObject bgPlane = transform.Find("BackgroundPlane").gameObject;
        bgPlane.layer = LayerMask.NameToLayer(bgLayerName);

        _cam = gameObject.GetComponent<Camera>();
        _cam.cullingMask = (int)bgCamCulling;

        // setup focus mode
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}