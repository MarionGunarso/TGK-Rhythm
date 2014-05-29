using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	// Use this for initialization
	public bool rightTap;
	private ScoreScript scoreScript;
	private GameOverScript gameOverScript;

	[HideInInspector]
	public bool tambahScore = true;

	void Start () {
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
