using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonDoorRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private ButtonDoorController raycastedObj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    [SerializeField] private Image crosshair = null;

    private bool isCrosshairActive;
    private bool doOnce;
    private const string interactableTag = "DoorButton";

    [SerializeField] private TextMeshProUGUI pressEToInteractText;

    // Update is called once per frame
   private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ButtonDoorController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastedObj.PlayAnimation();
                }
            }

        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
        
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
            pressEToInteractText.gameObject.SetActive(true);
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
            pressEToInteractText.gameObject.SetActive(false);
        }
    }
}
