using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouWin: MonoBehaviour
{
	public GameObject Player;//gets player
	private PlayerController playercontroller;       // Reference to the player
	public float restartDelay = 5f;         // Time to wait before restarting the level
	Animator anim;                          // Reference to the animator component.
	float restartTimer; 
	private bool Winbool;


	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
		//player = GameObject.FindGameObjectWithTag ("Player");
		playercontroller = Player.GetComponent<PlayerController>();

	}

		
	void Update()
	{
		if (playercontroller.Winbool == true)//if it is a the win object
		{
			// ... tell the animator the game is over.
			anim.SetTrigger ("YouWin");

			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;

			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}