using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float cameraRotationLimit = 85f;

    //action réelle
    private Vector3 velocity;
    private Vector3 rotation;
    private float cameraRotationX;
    private float currentCameraRotationX = 0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity) // pour ne pas confondre avec l'autre velocity
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation) // pour ne pas confondre avec l'autre velocity
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _cameraRotation) // pour ne pas confondre avec l'autre velocity
    {
        cameraRotationX = _cameraRotation;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        //cam.transform.Rotate(-cameraRotationX);

        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //bloquer a une valeur min et max

        //on applique la rotation
        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
}
