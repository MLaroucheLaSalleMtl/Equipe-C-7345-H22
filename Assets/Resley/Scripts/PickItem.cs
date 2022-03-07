using UnityEngine;

public class PickItem : Interactible
{
    public override void Interact()
    {
        base.Interact();

        void PickUp ()
        {
            Debug.Log("Item picked");

            Destroy(gameObject);
        }
    }
}
