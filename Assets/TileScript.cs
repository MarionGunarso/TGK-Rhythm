using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	// Use this for initialization
	public bool rightTap; //indicate the right tile

	private ScoreScript scoreScript;
	private GameOverScript gameOverScript;

	[HideInInspector]
	public bool tambahScore = false; //variable to help make addScore only once

	void Start () {
		if(rightTap==true)
		{
			tambahScore = true;
		}
		gameOverScript = GameObject.FindGameObjectWithTag("gameOver").GetComponent<GameOverScript>();
		scoreScript = GameObject.FindGameObjectWithTag("score").GetComponent<ScoreScript>();
	}


	void OnMouseDown()
	{
		if(gameOverScript.gameOver == false)
		{
			if(rightTap==true)
			{
				if(tambahScore==true)
				{
					scoreScript.AddScore(1);
					tambahScore = false;
				}

			}
			else
			{
				gameOverScript.gameOver = true;
			}
		}

	}
	public void Reset()
	{
		tambahScore = true;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
