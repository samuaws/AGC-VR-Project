using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls controls;
    PlayerControls.MovementActions Movement;
    [SerializeField]Walk walk;
    [SerializeField]MouseLook mouseLook;
    Vector2 walkInput;
    Vector2 mouseInput;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        Movement = controls.Movement;
        Movement.Walk.performed += ctx => walkInput = ctx.ReadValue<Vector2>();
        Movement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        Movement.MouseX.performed += ctx => print("what is wrong with you");
        Movement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        controls.Mouse.lClick.performed += _ => mouseLook.LeftClick();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        walk.RecieveInput(walkInput);
        mouseLook.RecieveInput(mouseInput);
    }
}
