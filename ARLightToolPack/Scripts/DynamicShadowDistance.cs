using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicShadowDistance : MonoBehaviour {

	public Transform targetObj;
	public float camToObjDist = 0.0f;

	// Update is called once per frame
	void Update () {
		camToObjDist = Vector3.Distance (transform.position, targetObj.position);
		QualitySettings.shadowDistance = camToObjDist * 1.5f;
	}
}
