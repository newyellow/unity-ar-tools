using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldImageGrabber : MonoBehaviour
{
    public static WorldImageGrabber Instance;
    public Camera realWorldCamera;

    public RenderTextureSizeSetting renderTextureSize;
    public RenderTexture _renderTex;

    private void Awake()
    {
        Instance = this;

        switch (renderTextureSize)
        {
            case RenderTextureSizeSetting.Full:
                _renderTex = new RenderTexture(Screen.width, Screen.height, 16);
                break;

            case RenderTextureSizeSetting.Half:
                _renderTex = new RenderTexture(Screen.width / 2, Screen.height / 2, 16);
                break;

            case RenderTextureSizeSetting.Quater:
                _renderTex = new RenderTexture(Screen.width / 4, Screen.height / 4, 16);
                break;
        }

        realWorldCamera.targetTexture = _renderTex;
    }
}
