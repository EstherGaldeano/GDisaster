using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class EnemyMove : MonoBehaviour {
    [SerializeField]Transform player;
	private UnityEngine.AI.NavMeshAgent nav;
	private Animator anim;

	//private EnemyHealth enemyHealth;

	// Use this for initialization
	void Start () {

		//player = GameManager.instance.Player.transform;
	//	enemyHealth = GetComponent<EnemyHealth> ();
		anim = GetComponent<Animator> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	
	}
	
	void Update () {
        
        //if the player is dead, the enemies have to stay idle not following her

		if (!GameManager.instance.GameOver/* && enemyHealth.IsAlive*/) {

            nav.SetDestination (player.position);
            //	} else if ((!GameManager.instance.GameOver || GameManager.instance.GameOver) && !enemyHealth.IsAlive) {
            //	nav.enabled = false;

        } else {//debería pararse pero no funciona :s
            nav.enabled = false;
            anim.Play("Idle");
        }

    }
}
