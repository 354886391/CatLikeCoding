using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0, 100f)]
    float maxSpeed = 10f;
    [SerializeField, Range(0, 100f)]
    float maxAcceleration = 10f;
    Vector3 velocity;
    [SerializeField]
    Rect allowedArea = new Rect(-5f, -5f, 10f, 10f);


    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        //playerInput.Normalize();
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        //transform.localPosition = new Vector3(playerInput.x, 0f, playerInput.y);
        //Vector3 displacement = new Vector3(playerInput.x, 0f, playerInput.y);
        //transform.localPosition += displacement;
        //Vector3 velocity = new Vector3(playerInput.x, 0f, playerInput.y);
        //Vector3 displacement = velocity * Time.deltaTime;
        //transform.localPosition += displacement;
        //Vector3 acceleration = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        //velocity += acceleration * Time.deltaTime;
        //Vector3 displacement = velocity * Time.deltaTime;
        //transform.localPosition += displacement;
        Vector3 desiredVeleocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        //if (velocity.x < desiredVeleocity.x)
        //{
        //    velocity.x = Mathf.Min(velocity.x + maxSpeedChange, desiredVeleocity.x);
        //}
        //else if (velocity.x > desiredVeleocity.x)
        //{
        //    velocity.x = Mathf.Max(velocity.x - maxSpeedChange, desiredVeleocity.x);
        //}
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVeleocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVeleocity.z, maxSpeedChange);
        //Vector3 acceleration = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        //velocity += acceleration * Time.deltaTime;
        Vector3 displacement = velocity * Time.deltaTime;

        Vector3 newPosition = transform.localPosition + displacement;
        //transform.localPosition = newPosition;
        //if (!allowedArea.Contains(new Vector2(newPosition.x, newPosition.z)))
        //{
        //    //newPosition = transform.localPosition;
        //    newPosition.x = Mathf.Clamp(newPosition.x, allowedArea.xMin, allowedArea.xMax);
        //    newPosition.z = Mathf.Clamp(newPosition.z, allowedArea.yMin, allowedArea.yMax);
        //}
        if (newPosition.x < allowedArea.xMin)
        {
            newPosition.x = allowedArea.xMin;
            velocity.x = 0f;
        }
        else if (newPosition.x > allowedArea.xMax)
        {
            newPosition.x = allowedArea.xMax;
            velocity.x = 0f;
        }
        if (newPosition.z < allowedArea.yMin)
        {
            newPosition.z = allowedArea.yMin;
            velocity.z = 0f;
        }
        else if (newPosition.z > allowedArea.yMax)
        {
            newPosition.z = allowedArea.yMax;
            velocity.z = 0f;
        }
        transform.localPosition = newPosition;
    }
}
