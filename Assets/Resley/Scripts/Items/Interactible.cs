using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;
    public Transform interationTransform;

    //KeyCode rightMouse = KeyCode.Mouse1;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact ()
    {
        Debug.Log("Interacting whit " + transform.name);
    }

    private void Update()
    {
        if (isFocus && !hasInteracted /*&& Input.GetKey(rightMouse)*/)
        {
            float distance = Vector3.Distance(player.position, interationTransform.position);
            if (!hasInteracted && distance <= radius)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interationTransform == null)
            interationTransform = transform;


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interationTransform.position,radius);

    }

}
