using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform interactionPoint;
    public float interactionPointRadius = 0f;
    [SerializeField] LayerMask interactableMask;
    [SerializeField] InteractionPromptUI interactionPromptUI;

    readonly Collider[] colliders = new Collider[3];
    [SerializeField] int numFound;

    IInteractable interactable;

    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
        
        if (numFound > 0) {
            var interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null) {
                if (!interactionPromptUI.isDisplayed) interactionPromptUI.SetUp(interactable.InteractionPrompt);
                    if (Input.GetKeyDown(KeyCode.E)) interactable.Interact(this);
            }
        }
        else {
            if (interactable != null) interactable = null;
            if (interactionPromptUI.isDisplayed) interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);  
    }
}