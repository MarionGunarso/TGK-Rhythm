﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingBakground : MonoBehaviour
{

	public float bpm;
	/// <summary>
	/// Scrolling speed
	/// </summary>

	public Vector2 speed = new Vector2(10, 10);
	//public PlayerScript playerScript;
	//public float speedModifier;
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	/// <summary>
	/// Movement should be applied to camera
	/// </summary>
	public bool isLinkedToCamera = false;
	
	/// <summary>
	/// 1 - Background is infinite
	/// </summary>
	public bool isLooping = false;

	public TileSpawner tileSpawner;
	/// <summary>
	/// 2 - List of children with a renderer.
	/// </summary>
	private List<Transform> backgroundPart;

	//private PlayerScript playerScript;

	GameOverScript gameOverScript;

	// 3 - Get all the children
	void Start()
	{
		speed = new Vector2(speed.x , 0.0309f*bpm);
		gameOverScript = GameObject.FindGameObjectWithTag("gameOver").GetComponent<GameOverScript>();
		//playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
		// For infinite background only
		if (isLooping)
		{
			// Get all the children of the layer with a renderer
			backgroundPart = new List<Transform>();
			
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				
				// Add only the visible children
				//if (child.renderer != null)
				//{
					backgroundPart.Add(child);
				//}
			}
			
			// Sort by position.
			// Note: Get the children from left to right.
			// We would need to add a few conditions to handle
			// all the possible scrolling directions.
			backgroundPart = backgroundPart.OrderBy(
				t => t.position.y
				).ToList();
		}

	}
	
	void Update()
	{

		// 4 - Loop
		if (isLooping)
		{
			// Get the first object.
			// The list is ordered from left (x position) to right.
			Transform firstChild = backgroundPart.FirstOrDefault();
			
			if (firstChild != null)
			{
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				if (firstChild.position.y < Camera.main.transform.position.y)
				{
					// If the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if (firstChild.renderer.IsVisibleFrom(Camera.main) == false)
					{
						TileScript[] tiles = firstChild.GetComponentsInChildren<TileScript>();
						//check all tile in row, if there's still any untapped tiles, gameOver
						foreach(TileScript tile in tiles)
						{
							if(tile.rightTap==true)
							{
								if(tile.tambahScore==true)
								{
									gameOverScript.gameOver=true;
									break;
								}
							}

						}


						// Get the last child position.
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						//Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
						
						// Set the position of the recyled one to be AFTER
						// the last child.
						// Note: Only work for horizontal scrolling currently.
						firstChild.GetComponent<RandomizeTileScript>().RemoveList();
						firstChild.GetComponent<RandomizeTileScript>().CheckTiles();
						firstChild.GetComponent<RandomizeTileScript>().SwapTiles();

						foreach(TileScript tile in tiles)
						{
							tile.Reset();
						}
						firstChild.position = new Vector3(firstChild.position.x, lastPosition.y + 1.85f, firstChild.position.z);
						
						// Set the recycled child to the last position
						// of the backgroundPart list.
						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
				}
			}
		}
	}

	void FixedUpdate()
	{
		
		// Movement
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		// Move the camera
		if (isLinkedToCamera)
		{
			Camera.main.transform.Translate(movement);
		}
	}
}
