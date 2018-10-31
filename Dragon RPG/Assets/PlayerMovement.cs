using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    [SerializeField] float posTolerance = 0.25f;
        
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            //print("Cursor raycast hit" + cameraRaycaster.Hit.collider.gameObject.name.ToString());
            currentClickTarget = cameraRaycaster.Hit.point;  // So not set in default case
        }
        if (cameraRaycaster.layerHit == Layer.Walkable &&
            Vector3.Distance(transform.position, currentClickTarget) > posTolerance)
        {
            m_Character.Move(currentClickTarget - transform.position, false, false);
        }
    }
}

