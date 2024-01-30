using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;

    float rotX;
    float rotY;
    float rotZ;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = (rotX*rotY)*transform.rotation*(rotY*rotX);
        }

    }
    public Quaternion Conjugate(Quaternion q)
    {
        return new Quaternion(-q.x, -q.y, -q.z, q.w);
    }



}
