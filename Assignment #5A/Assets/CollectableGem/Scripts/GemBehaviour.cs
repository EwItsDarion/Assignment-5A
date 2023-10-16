using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GemBehaviour : MonoBehaviour
{
	public int score = 0;
	public bool win;
	public bool lose;
	public Text textbox;
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;

	private float durationOfCollectedParticleSystem;


	void Start()
	{
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
		textbox = GetComponent<Text>();
		textbox.text = "Score: 0";
	}

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void Update()
	{
		if (score < 10)
		{
			textbox.text = "Score: " + score;
		}
		if(score == 10)
		{
			win = true;
			textbox.text = "You win!";
		}
	}

	void GemCollected()
	{
		gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
		Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);
		score += 1;

	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}
