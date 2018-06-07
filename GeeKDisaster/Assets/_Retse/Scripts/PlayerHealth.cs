using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] int startingHealth = 100; //Hero Health
	[SerializeField] float timeSinceLastHit = 2f; 
	[SerializeField] Slider healthSlider; //health bar

	private float timer = 0f; //time bwtween hits
	private CharacterController characterController; //if the hero dies, it has to stop moving
	private Animator anim;
	private int currentHealth;
    private AudioSource audio;
 
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value < 0)
                currentHealth = 0;
            else
                currentHealth = value;
        }
    }

    void Awake() {
        Assert.IsNotNull(healthSlider);
    }


    void Start () {

		anim = GetComponent<Animator> ();
	    characterController = GetComponent<CharacterController> ();
	    currentHealth = startingHealth;
        audio = GetComponent<AudioSource>();

    }


    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        //if the time since last hit it's ok and isn't game over
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {

            if (other.tag == "Weapon")
            {
                takeHit();
                timer = 0;
            }
        }
    }

    //when the player receive an attack
    void takeHit()
    {

        if (currentHealth > 0)
        {
          
            if (Input.GetMouseButtonDown(1)) {
              currentHealth -= 1;

            } else {

                currentHealth -= 10;
            }

            GameManager.instance.PlayerHit(currentHealth);
            anim.Play("Hurt");

            healthSlider.value = currentHealth;//every hit decrease the health bar
            audio.PlayOneShot(audio.clip); //sound when we're hited
        }

        if (currentHealth <= 0)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        //if player dies start Die Animation and enable movement
        GameManager.instance.PlayerHit(currentHealth);
        anim.SetTrigger("HeroDie");
        characterController.enabled = false;

    }

    public void PowerUpHealth() {

        if (currentHealth <= 70) {
            CurrentHealth += 30;

        } else if (currentHealth < startingHealth) {

            CurrentHealth = startingHealth;
        }

        healthSlider.value = currentHealth;
    }
}
