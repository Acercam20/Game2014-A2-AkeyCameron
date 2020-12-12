using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformDirection { 
        Vertical,
        Horizontal,
        DiagonalUp,
        DiagonalDown
};

public class MovingPlatform : MonoBehaviour
{
    public float travelDistance;
    public float travelSpeed;
    public Vector3 startingPosition;
    public PlatformDirection platformDirection;
    public bool flip = false;
    public float startDelay = 0.0f;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay(startDelay));
        startingPosition = transform.position;
    }

    IEnumerator StartDelay(float time)
    {
        yield return new WaitForSeconds(time);

        isActive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
            MoveInDirection();
    }

    private void MoveInDirection()
    {
        switch(platformDirection)
        {
            case PlatformDirection.Vertical: //Vertical
                //Debug.Log("limit: " + travelDistance);
                if (transform.position.y >= startingPosition.y + travelDistance)
                {
                    flip = false;
                }
                else if(transform.position.y <= startingPosition.y - travelDistance)
                {
                    flip = true;
                }
                if (flip)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + travelSpeed / 1000, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - travelSpeed / 1000, transform.position.z);
                }
                break;
            case PlatformDirection.Horizontal: //Horizontal
                if (transform.position.x >= startingPosition.x + travelDistance)
                {
                    flip = false;
                }
                else if (transform.position.x <= startingPosition.x - travelDistance)
                {
                    flip = true;
                }
                if (flip)
                {
                    transform.position = new Vector3(transform.position.x + travelSpeed / 1000, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - travelSpeed / 1000, transform.position.y, transform.position.z);
                }
                break;
            case PlatformDirection.DiagonalUp: // Diagonal Ascending
                if (transform.position.y >= startingPosition.y + travelDistance)
                {
                    flip = false;
                }
                else if (transform.position.y <= startingPosition.y - travelDistance)
                {
                    flip = true;
                }
                if (flip)
                {
                    transform.position = new Vector3(transform.position.x + travelSpeed / 1000, transform.position.y + travelSpeed / 1000, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - travelSpeed / 1000, transform.position.y - travelSpeed / 1000, transform.position.z);
                }
                break;
            case PlatformDirection.DiagonalDown: // Diagonal Descending
                if (transform.position.y >= startingPosition.y + travelDistance)
                {
                    flip = false;
                }
                else if (transform.position.y <= startingPosition.y - travelDistance)
                {
                    flip = true;
                }
                if (flip)
                {
                    transform.position = new Vector3(transform.position.x - travelSpeed / 1000, transform.position.y + travelSpeed / 1000, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + travelSpeed / 1000, transform.position.y - travelSpeed / 1000, transform.position.z);
                }
                break;
            default:
                Debug.Log("Platform Direction enum error (MovingPlatform.cs)");
                break;
        }

        //transform.velocity = new Vector3(transform.velocity.x, transform.velocity.y, transform.velocity.z);
    }

}
