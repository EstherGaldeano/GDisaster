using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth2 : MonoBehaviour {

    [SerializeField]
    private int startingHealth = 20; //life of the enemy at the start
    [SerializeField]
    private float timeSinceLastHit = 0.5f;
    [SerializeField]
    private float dissapearSpeed = 2f; //when the enemy dies, dissapears in this time

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
        get { return isAlive; }
    }

    public int Getlife {
        get { return currentHealth; }
    }


    // Use this for initialization
    void Start() {

        GameManager.instance.RegisterEnemy(this);
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
  
        isAlive = true;
        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update() {

        //to control the time between hits
        timer += Time.deltaTime;

       

        //if the enemy dies, change isAlive to false and do KillEnemy method
        if (Input.GetKeyDown(KeyCode.Z)) {
          //  rigidBody.isKinematic = true;
            Destroy(gameObject);


        }
    }
    

}
