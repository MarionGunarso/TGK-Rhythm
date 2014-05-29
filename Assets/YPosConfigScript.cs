using UnityEngine;
using System.Collections;

public class YPosConfigScript : MonoBehaviour {

	// Use this for initialization
	public TileSpawner tileSpawner;

	private float basePosY;
	public GameObject [] gameObjects;
	int a;
	void Awake () {
		a=1;
		basePosY = this.transform.position.y;
		Debug.Log(tileSpawner.tileHeight*a);
		foreach(GameObject gameObject in gameObjects)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, basePosY + (tileSpawner.tileHeight*a), gameObject.transform.position.z);
			a++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
