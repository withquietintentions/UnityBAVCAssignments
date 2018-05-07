using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour {
	
	public Text countTextL1;//UI text that counts pickups Level 1
	public Text countTextL2;//UI text that counts pickups Level 2
	public Text level;
	private int L1count;
	private int L2count;
	public bool Winbool;//
	//public float restartDelay = 5f;       
	//Animator anim;                          // Reference to the animator component.
	//float restartTimer; 
	public Image winImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.5f);

	public GameObject Door1;
	public GameObject Door2;

	//Audio
	public AudioClip PickUpSound;
	public AudioClip WinSound;
	public AudioClip UnlockSound;//sound for when player gets all the cubes they need
	private AudioSource source;//add your audio
	private AudioSource source1;//add your audio
	private AudioSource source2;//add your audio

	//end Audio

	void Start (){
		Winbool = false;
		Debug.Log ("are you synching?");
		L1count = 0;//starts objects obtained at 0
		L2count = 0;
		Level1 ();//call function below
		countTextL1.text ="0/3";
		countTextL2.text = "";
		level.text = "Level 1";
		source2 = GetComponent<AudioSource>();//ADD your audio for when they get it
		source1 = GetComponent<AudioSource>();//ADD your audio for when they get it
		source = GetComponent<AudioSource>();//ADD your audio for when they get it

	}


	void OnTriggerEnter(Collider other) //when we collide
	{
		if (other.gameObject.CompareTag ("Pick Up 1"))//if it is a pick op object
		{
			other.gameObject.SetActive (false);//set them to deactivate
			L1count = L1count + 1;//add the number picked up by one
			source2.PlayOneShot(PickUpSound, 1F);
			Level1 ();
			Debug.Log("L1count " + L1count);
		}
		if (other.gameObject.CompareTag ("Pick Up 2"))//if it is a pick op object
		{
			other.gameObject.SetActive (false);//set them to deactivate
			L2count = L2count + 1;//add the clock number by one
			source2.PlayOneShot(PickUpSound, 1F);
			Level2 ();
			Debug.Log("L2count " + L2count);
		}
		if (other.gameObject.CompareTag ("WinObject"))//if it is a pick op object
		{
			Winbool = true;
			source1.PlayOneShot(WinSound, 1F);
			Debug.Log("Winbool: " + Winbool);
		}

	}

	public void Level1()
	{
		
		countTextL1.text = L1count.ToString () + " / 3";//makes UI say Clock and the number out of 3
		if (L1count >= 3)//if they get all the clock
			{
			//winText.text = "You got thru Barrier TIME Good job!";//text says they got thru the 1st barrier
			//StartCoroutine(Example());
			//winText.text = "";//text back to blank
			winImage.color = flashColor;
			winImage.color = Color.Lerp (winImage.color, Color.clear, flashSpeed * Time.deltaTime);
			Destroy (Door1);//the doorway is destryed so we can pass through
			source.PlayOneShot(UnlockSound, 1F);
			level.text = "Level 2";

		}
	
}
	public void Level2()
	{

		countTextL2.text = L2count.ToString () + " /4";//makes UI say Clock and the number out of 3
		if (L2count >= 4)//if they get all the clocks
		{
			
			//winText.text = "You got thru Barrier FEAR Good job!";//text says they got thru the 1st barrier
			Destroy (Door2);//the doorway is destryed so we can pass through
			level.text = "Level 3";
			source.PlayOneShot(UnlockSound, 1F);

		}
	}
		
}
