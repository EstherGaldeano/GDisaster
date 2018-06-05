using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour {

	[SerializeField] private int startingHealth = 20; //life of the enemy at the start
	[SerializeField] private float timeSinceLastHit = 0.5f; 
	[SerializeField] private float dissapearSpeed = 2f; //when the enemy dies, dissapears in this time

	private AudioSource audio;
	private float timer = 0f;
	private Animator anim;
	private UnityEngine.AI.NavMeshAgent nav;
	private bool isAlive;
	private Rigidbody rigidBody;
	private CapsuleCollider capsuleCollider;
	private bool dissapearEnemy = false;
	private int currentHealth;
	private ParticleSystem blood;

    //we do a geter for this to access with other scripts
	public bool IsAlive {
		get {return isAlive; }
	}

    public int Getlife {
        get { return currentHealth; }
    }


    // Use this for initialization
    void Start () {

		GameManager.instance.RegisterEnemy (this);
		rigidBody = GetComponent<Rigidbody> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		isAlive = true;
		currentHealth = startingHealth;
		blood = GetComponentInChildren<ParticleSystem> ();
	
	}
	
	// Update is called once per frame
	void Update () {

        //to control the time between hits
		timer += Time.deltaTime;

        //if enemy dies, it dissapears going down of the terrain
		if (dissapearEnemy) {
			transform.Translate (-Vector3.up * dissapearSpeed * Time.deltaTime);
		}
	}

    //when we enter the collider of the enemy, it will be hurt by the player weapon
	void OnTriggerEnter (Collider other) {

		if(timer >= timeSinceLastHit && !GameManager.instance.GameOver) {
			if (other.tag == "PlayerWeapon") {
				takeHit ();
		//		blood.Play ();
				timer = 0f;
			}
		}
	}

    //when the enemy receives a hit, an audio sounds and the health is reduced 10 points
	void takeHit() {

		if (currentHealth > 0) { //if is alive
			audio.PlayOneShot (audio.clip); //play hurt sound
			anim.Play ("Hurt");
            currentHealth -= 10;

		}
        //if the enemy dies, change isAlive to false and do KillEnemy method
		if (currentHealth <= 0) {
			isAlive = false;
			KillEnemy ();
		}

	}

    //if the enemy dies, show die animation, disable the collider and use removeEnemy method
	void KillEnemy() {

		GameManager.instance.KilledEnemy (this);
		capsuleCollider.enabled = false;
		nav.enabled = false;
		anim.SetTrigger ("EnemyDie");
		rigidBody.isKinematic = true;
		StartCoroutine (removeEnemy());

	}

    //the enemy dissapears after the time we type
	IEnumerator removeEnemy() {
        //wait before enemy dies
		yield return new WaitForSeconds (4f);
        
        //start to sink the enemy
        dissapearEnemy = true;
        //after 2 seconds
        yield return new WaitForSeconds (2f);
        //destroy the object
        Destroy (gameObject);
	}

}
