using UnityEngine;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine.XR;

public class ShipMovement : MonoBehaviour
{
    [Header("Movement")]
    //Speed of movement
    [SerializeField] float speed;
    //Sets the speed of rotation
    [SerializeField] float angle = 2;

    private Vector2 input;

    Quaternion pitchY;
    Quaternion rollZ;

    //Quaternion X = ;

//CALLING INPUTS - Defined in Unity Input Manager
    private void Update()
    {
        //Inputs to get axis based on x, Vertical is not used
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * Time.deltaTime;

        //Use theta to calculate the Quaternion of the rotation, the angle used her is the angle used in the Theta function
        pitchY = theta(Vector3.up, angle * input.x );
        rollZ = theta(Vector3.forward, angle * -input.x);

        //transform.localRotation = Using rotation of the SHIP and not the world your ship can now rotate multipled by the Quaternion Rotations
        transform.localRotation = pitchY * transform.localRotation * rollZ;

        //GO FORWARD
        transform.position += transform.forward * speed * Time.deltaTime;

    }

//QUATERNION TO THETA ANGLE
    private Quaternion theta(Vector3 axis, float angle)
    {
        //Translate the angles which are in Degrees into Radians
        angle = Mathf.Deg2Rad * angle;

        //Taking the axis of rotation, and finding the Theta angle, converts it to Quaternion
        Quaternion rotation = new Quaternion
            
            (
            axis.x * Mathf.Sin(angle / 2),
            axis.y * Mathf.Sin(angle / 2),
            axis.z * Mathf.Sin(angle / 2),
            Mathf.Cos(angle / 2)
            );

        return rotation;
        //Rotates the ship
            
    }

}
