using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyObjectZ : MonoBehaviour {


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {


        if (Input.GetKeyDown(KeyCode.Z)) {

            Destroy(gameObject);

        }
    }   

}
