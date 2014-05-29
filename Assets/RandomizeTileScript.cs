using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomizeTileScript : MonoBehaviour {

	// Use this for initialization
	private List<Transform> childrenTilesList = new List<Transform>();
	Transform [] childrenTiles;

	List<int> indexRightTap = new List<int>();
	int [] indexRightTapArray;

	IEnumerator WaitToAdd()
	{
		yield return new WaitForSeconds(0.005f);
		foreach(Transform child in this.transform)
		{
			childrenTilesList.Add(child);
		}
		childrenTiles = childrenTilesList.ToArray();
	}

	void Start () {
		StartCoroutine(WaitToAdd());
	
	}

	public void CheckTiles()
	{
		for(int i=0 ; i<childrenTiles.Length ; i++)
		{
			
			if(childrenTiles[i].GetComponent<TileScript>().rightTap == true)
			{
				indexRightTap.Add(i);

				
			}
		}
		indexRightTapArray = indexRightTap.ToArray();
	}
	public void RemoveList()
	{
		indexRightTap.Clear();
	}

	public void SwapTiles()
	{
		for(int i=0 ; i<indexRightTapArray.Length; i++)
		{
			int b = Random.Range(0,childrenTiles.Length);
			if(b!=indexRightTapArray[i])
			{
				float xTemp = childrenTiles[b].transform.position.x;
				childrenTiles[b].transform.position = new Vector3(childrenTiles[indexRightTapArray[i]].transform.position.x, childrenTiles[b].transform.position.y, childrenTiles[b].transform.position.z);
				//childrenTiles[b].transform.position.x = childrenTiles[indexRightTapArray[i]].transform.position.x;
				childrenTiles[indexRightTapArray[i]].transform.position = new Vector3(xTemp,childrenTiles[indexRightTapArray[i]].transform.position.y, childrenTiles[indexRightTapArray[i]].transform.position.z);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
