using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public static int DinoCount = 0;
    public int DinoValue = 1;

    // Se llama al iniciar el juego

    void Awake() {
        Enemy.DinoCount += DinoValue;
    }


    //cuando se destruye un objeto

    void OnDestroy() {
        Enemy.DinoCount -= DinoValue;
        UI_enemy.UpdateDinos();

        if (Enemy.DinoCount <= 0) {

            Debug.Log("Todos eliminados");
        }

    }

}