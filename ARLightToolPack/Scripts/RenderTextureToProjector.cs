using UnityEngine;
using System.Collections;

public class RenderTextureToProjector : MonoBehaviour {

	public RenderTexture _texture;
	public Projector _projector;

	// Use this for initialization
	void Start () {

		_texture = new RenderTexture (Screen.width, Screen.height, 16);
		gameObject.GetComponent<Camera> ().targetTexture = _texture;

		_projector.material.SetTexture ("_ShadowTex", _texture);
	}
}
