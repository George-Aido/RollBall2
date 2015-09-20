using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	public Text countText;
	private Rigidbody rb;
	private int count;
	private int pickupsNumber;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		pickupsNumber = GameObject.FindGameObjectsWithTag ("PickUp").Length;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * Speed);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			count++;
			pickupsNumber--;
			SetCountText ();
		}
		if (pickupsNumber == 0) 
		{
			countText.text = "You won!";
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
	}
}
