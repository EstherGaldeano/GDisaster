using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportDungeon : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player") {
            // cambiarNivel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        
    }

  IEnumerator cambiarNivel()
    {
        
        float timeDes = GameObject.Find("Player").GetComponent<CambiarScena>().EmpezarDes(1);
        yield return new WaitForSeconds(timeDes);
        //Application.LoadLevel(Application.loadedLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
