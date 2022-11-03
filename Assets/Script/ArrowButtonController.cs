using UnityEngine;
using UnityEngine.Events;

public class ArrowButtonController : MonoBehaviour
{
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
                    if (Physics.Raycast(ray, out Hit))
                    {
                        switch (Hit.collider.gameObject.tag)
                        {
                            case "front":
                                Debug.Log("front");
                                OnClick.Invoke();
                                break;
                            case "back":
                                Debug.Log("back");
                                OnClick.Invoke();
                                break;
                            case "left":
                                Debug.Log("left");
                                OnClick.Invoke();
                                break;
                            case "right":
                                Debug.Log("right");
                                OnClick.Invoke();
                                break;
                        }
                    }
                }
            }
        }
    }
}
