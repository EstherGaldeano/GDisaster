using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour {

    [SerializeField]private float range = 3f; //range between enemy and hero
    [SerializeField]private float timeBetweenAttacks = 1f; //time between enemy attacks

    private Animator anim; //attack animation
    private GameObject player; //gameobject of the Hero
    private bool playerInRange; //keep on track whether we are within the especified range
    private BoxCollider[] weaponColliders; //colliders of the weapons
                                           //	private EnemyHealth enemyHealth;


    void Start() {

//        enemyHealth = GetComponent<EnemyHealth>();

        //children collider because the weapon collider
        //it's inside the enemy bones, not at the "general" enemy

        weaponColliders = GetComponentsInChildren<BoxCollider>();
        player = GameManager.instance.Player;
        anim = GetComponent<Animator>();

        //starts attack coroutine
        StartCoroutine(attack());
    }


    void Update() {

   // measure the distance between the enemy and the player using the range

   //**player doesn't have collider, if she has, this doesn't work, control the radius

        if (Vector3.Distance(transform.position, player.transform.position) < range) {
                playerInRange = true;
            } else {
                playerInRange = false;
            }

     //    Debug.Log(playerInRange);

    }

    //attack coroutine
IEnumerator attack() {

    if (playerInRange && !GameManager.instance.GameOver/* && enemyHealth.IsAlive*/) {

        anim.Play("Attack");
        yield return new WaitForSeconds(timeBetweenAttacks);
    }

    yield return null;
    StartCoroutine(attack());
}

    //public void EnemyBeginAttack() {
    //	foreach (var weapon in weaponColliders) {
    //		weapon.enabled = true;
    //	}
    //}

    //public void EnemyEndAttack() {
    //	foreach (var weapon in weaponColliders) {
    //		weapon.enabled = false;
    //	}
    //}
    //
}