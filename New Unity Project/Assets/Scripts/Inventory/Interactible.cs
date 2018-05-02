using UnityEngine;

public class Interactible : MonoBehaviour {

    bool isFocus = false;
    public float radius = 5f;
    bool hasInteracted = false;
    Transform player;
    
    public virtual void Interact()
    {
        // Este método es solo para sobre escribirse
    }

    void Update()
    {        
        //comprobamos si tenemeos algo enfocado
        if (isFocus && !hasInteracted)
        {
            // comprobamos la distancia a la que estamos
            float distance = Vector3.Distance(player.position, transform.position);
            //si estamos cerca interactuamos
            if (distance <= radius)
            {
                Interact();        
                hasInteracted = true;                
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void DeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
