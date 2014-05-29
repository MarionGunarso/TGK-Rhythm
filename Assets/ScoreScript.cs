using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization
	public TextMesh textMesh;

	public int score;

	void Start () {

	}

	public void AddScore(int a)
	{
		score+=a;

	}

	public void ShowScore()
	{
		textMesh.text=score.ToString();
	}

	public void ResetScore()
	{
		score = 0;
	}
	// Update is called once per frame
	void Update () {
		ShowScore();
	}
}
