using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    public float maxFallSpeed = 7f;
    public float height = 1f;
    public float width = 1f;
    public Vector3[] bottomRaycastVectors;
    public Vector3[] topRaycastVectors;
    public Vector3[] sideRaycastVectors;
    float skinWidth = 0.1f;
    [SerializeField] Vector3 yStoppingPoint;

    bool isJumping = false;
    bool isFalling = false;
    float charX;
    float charY;


    void FixedUpdate()
    {
        for (int y = 0; y < 3; y++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + bottomRaycastVectors[y], -Vector2.up, 0.5f);

            if(hit.collider != null)
            {
                float distance = hit.distance;
                if(distance <= skinWidth)
                {
                    isFalling = false;
                }

                else
                {
                    isFalling = true;
                    float distanceUsuallyTravelled = 1.0f * verticalSpeed;
                    
                    if(-distanceUsuallyTravelled < distance)
                    {
                        charY = transform.position.y + (-1.0f * distance * Time.deltaTime);
                    }
                    else
                    {
                        charY = transform.position.y + (distanceUsuallyTravelled * Time.deltaTime);
                    }
                    
                }
            }

            else
            {
                charY = transform.position.y + (1.0f * verticalSpeed * Time.deltaTime);
            }

            charX = transform.position.x;

            transform.position = new Vector3(charX, charY);

            Vector3 rayBegin = transform.position + bottomRaycastVectors[y];
            Debug.DrawRay(rayBegin, -Vector3.up * 0.5f, Color.red);

            /*if(hit.collider != null)
            {

            }*/

        }

        //transform.position = new Vector3(transform.position.x, transform.position.y + (maxFallSpeed * -1f * Time.deltaTime), 0f);
    }
}
