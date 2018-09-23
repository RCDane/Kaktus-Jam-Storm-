using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RenderRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var tilemap = GetComponent<Tilemap>();
        var rend = tilemap.GetComponent<TilemapRenderer>();
        rend.enabled = false;
	}


}
