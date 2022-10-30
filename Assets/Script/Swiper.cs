using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour
{

    private Touch initTouch = new Touch();
    public Camera cam;

    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;

    public float rotationSpeed = 1f;
    public float speed = 4f;
    public float dir = -1;

    private Vector2 curDist = new Vector2(0, 0);
    private Vector2 prevDist = new Vector2(0,0);
    private float touchDelta = 0.0f;
    private float speedTouch0 = 0.0f;
    private float speedTouch1 = 0.0f;
    private float varianceInDistances = 5.0f;
    private float minPinchSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            foreach (Touch touch in Input.touches)
            {
            
                if (touch.phase == TouchPhase.Began)
                {
                    initTouch = touch;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    //swiping
                    float deltaX = initTouch.position.x - touch.position.x;
                    float deltaY = initTouch.position.y - touch.position.y;

                    rotX -= deltaY * Time.deltaTime * rotationSpeed * dir;
                    rotY += deltaX * Time.deltaTime * rotationSpeed * dir;

                    rotX = Mathf.Clamp(rotX, -45f, 45f);

                    cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    initTouch = new Touch();
                }
            }
        }

        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                curDist = Input.GetTouch(0).position - Input.GetTouch(1).position; //current distance between finger touches
                prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition)); //difference in previous locations using delta positions
                touchDelta = curDist.magnitude - prevDist.magnitude;
                speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
                speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;
                if ((touchDelta + varianceInDistances <= 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
                {
                    cam.fieldOfView = Mathf.Clamp(cam.fieldOfView + (1 * speed), 15, 90);
                }
                if ((touchDelta + varianceInDistances > 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
                {
                    cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (1 * speed), 15, 90);
                }
            }
        }
    }
}
