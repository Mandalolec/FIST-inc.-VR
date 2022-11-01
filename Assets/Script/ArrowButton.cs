using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowButton : MonoBehaviour
{
    private Touch initTouch = new Touch();
    public GameObject defindedButton;
    public Camera cam;

    public UnityEvent OnClick = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        defindedButton = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Stationary)
                {
                    var ray = cam.ScreenPointToRay(touch.position);
                    RaycastHit Hit;
                    if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject.CompareTag("front"))
                    {
                        Debug.Log("click");
                        OnClick.Invoke();
                    }
                    else
                    {
                        Debug.Log("no ray");
                    }
                }
                else
                {
                    Debug.Log("no touch");
                }
            }

            //RaycastHit hitInfo = new RaycastHit();
            //bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hitInfo);
            //if (hit)
            //{
            //    if (hitInfo.transform.gameObject.tag == "front")
            //    {
            //        Debug.Log("Front!");
            //    } else { Debug.Log("hmmm");}
            //} else {Debug.Log("no hit");
        }
    }
}
