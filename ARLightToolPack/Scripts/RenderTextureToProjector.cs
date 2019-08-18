using UnityEngine;
using System.Collections;

public class RenderTextureToProjector : MonoBehaviour {

	public RenderTexture _texture;
	public Projector _projector;

    public void SetupTexture(RenderTextureSizeSetting textureSize)
    {
        int textureWidth = Screen.width;
        int textureHeight = Screen.height;

        if(textureSize == RenderTextureSizeSetting.Half)
        {
            textureWidth /= 2;
            textureHeight /= 2;
        }
        else if(textureSize == RenderTextureSizeSetting.Quater)
        {
            textureWidth /= 4;
            textureHeight /= 4;
        }

        _texture = new RenderTexture(textureWidth, textureHeight, 16);
        gameObject.GetComponent<Camera>().targetTexture = _texture;

        _projector.material.SetTexture("_ShadowTex", _texture);
    }
}
