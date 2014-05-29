using UnityEngine;
using System.Collections;

public class TileSpawner : MonoBehaviour {

	// Use this for initialization
	//public GameObject tilesTrue;
	public GameObject [] tiles;
	public GameObject [] rows;

	public float basicPosX;
	public float basicPosY;

	private float posX;
	private float posY;

	private float tileWidth;

	[HideInInspector]
	public float tileHeight;

	public int column;
	void Awake()
	{
		tileWidth = tiles[0].transform.renderer.bounds.size.x;
		tileHeight = tiles[0].transform.renderer.bounds.size.y;
		Debug.Log(tileHeight);
		posX = basicPosX;
		posY = basicPosY;
	}
	void Start () {


		for (int y=0; y<rows.Length ; y++)
		{
			int a = Random.Range(0,column);
			posX = basicPosX;
			for(int i=0; i<column ; i++)
			{
				if(i==a)
				{
					foreach(GameObject tile in tiles)
					{
						if(tile.GetComponent<TileScript>().rightTap==true)
						{
							GameObject tesTile = Instantiate(tile,new Vector3(posX,posY,0),transform.rotation) as GameObject;
							if(tesTile==null)
							{
								Debug.Log("emptyTile");
							}
							//tesTile.transform.localPosition = new Vector3(0,tesTile.transform.localPosition.y,tesTile.transform.localPosition.z);
							tesTile.transform.parent = rows[y].transform;
							break;

						}
					}
				}
				else
				{
					foreach(GameObject tile in tiles)
					{
						if(tile.GetComponent<TileScript>().rightTap==false)
						{
							GameObject tesTile = Instantiate(tile,new Vector3(posX,posY,0),transform.rotation) as GameObject;
							if(tesTile==null)
							{
								Debug.Log("emptyTile");
							}
							//tesTile.transform.localPosition = new Vector3(0,tesTile.transform.localPosition.y,tesTile.transform.localPosition.z);
							tesTile.transform.parent = rows[y].transform;
							break;
						}
					}
				}
				posX+=tileWidth;
			}
			posY+=tileHeight;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
