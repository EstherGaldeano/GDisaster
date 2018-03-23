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
	
	// Update is called once per frame
	void Update () {

	//	if (!GameManager.instance.GameOver && enemyHealth.IsAlive) {
			nav.SetDestination (player.position);
	//	} else if ((!GameManager.instance.GameOver || GameManager.instance.GameOver) && !enemyHealth.IsAlive) {
		//	nav.enabled = false;
		
	//	} else {
	//		nav.enabled = false;
			//anim.Play ("Idle");
	//	}
	
	}
}
