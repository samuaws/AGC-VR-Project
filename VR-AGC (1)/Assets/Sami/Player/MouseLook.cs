using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] [Range(0, 10)] float sensitivityX = 8f;
    [SerializeField] [Range(0, 10)] float sensitivityY = 1f;
    [SerializeField] Transform playerCamera;
    private Pickable m_Pickable, _onHold;
    [SerializeField] float xClamp=85f;
    [SerializeField] private Transform pickPlace;
    float xRotation = 0f;
    Vector3 targetRotation;
    private RaycastHit _hit;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void RecieveInput(Vector2 mouseInput)
    {
        transform.Rotate(Vector3.up, mouseInput.x * sensitivityX);
        xRotation -= mouseInput.y * sensitivityY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
    public void LeftClick()
    {
        Debug.Log("dhjvcchdchsdhcvcsdhvcshdvhjsdv hvs");
        if (_onHold)
        {
            _onHold.OnDrop();
            _onHold = null;

        }
        else if (m_Pickable != null)
        {
            _onHold = m_Pickable;
            _onHold.OnPick(pickPlace);

        }
    }

    void FixedUpdate()
    {
        if (_onHold == null && Physics.Raycast(playerCamera.position, playerCamera.TransformDirection(Vector3.forward), out _hit, 1))
        {
            if (_hit.transform.tag == "pickable")
            {
                m_Pickable = _hit.transform.gameObject.GetComponent<Pickable>();
                Debug.DrawRay(playerCamera.position, playerCamera.TransformDirection(Vector3.forward) * _hit.distance, Color.blue);
            }
            else
            {
                Debug.DrawRay(playerCamera.position, playerCamera.TransformDirection(Vector3.forward) * _hit.distance, Color.red);
                m_Pickable = null;
            } 
        }
        else
        {
                
            m_Pickable = null;
           
        }
        
    }
}

