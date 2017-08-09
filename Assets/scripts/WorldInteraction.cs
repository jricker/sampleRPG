using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) // 0 is there which means left mouse button
        {
            getInteraction();
        }
    }

    void getInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            playerAgent.updateRotation = true;
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Enemy" || interactedObject.tag == "Interactable Object" )
            {
                Debug.Log("Move To Enemy");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            /*
            if (interactedObject.tag == "Interactable Object")
            {
                Debug.Log("Move To Interactable Object" +
                    "");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
                //Debug.Log("Interactable Object");
            }
            */
            else
            {
                DialogueSystem.Instance.DialoguePanel.SetActive(false);
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;
                Debug.Log("Non interactable Object");
            }
        }

    }
}