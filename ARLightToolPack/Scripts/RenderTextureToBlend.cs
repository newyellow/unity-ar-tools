using UnityEngine;
using System.Collections;

public class RenderTextureToBlend : MonoBehaviour {

	public RenderTexture _texture;
	public Colorful.Blend _blend;

	// Use this for initialization
	void Start () {

		_texture = new RenderTexture (Screen.width, Screen.height, 16);
		gameObject.GetComponent<Camera> ().targetTexture = _texture;

		_blend.Texture = _texture;
	}
}
