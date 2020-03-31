using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextureOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.SetTexture("_ScreenTex", WorldImageGrabber.Instance._renderTex);
    }

}
