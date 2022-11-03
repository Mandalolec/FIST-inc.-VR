using UnityEngine;
using UnityEngine.Events;

public class ArrowButtonController : MonoBehaviour
{
    private Touch initTouch = new Touch();

    public GameObject defindedButton;
    public Camera camera;

    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        defindedButton = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            var ray = camera.ScreenPointToRay(touch.position);
            RaycastHit Hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out Hit))
                {
                    Debug.Log(Hit.collider.gameObject.tag.ToString());
                    SwitchPicture(Hit.collider.gameObject.tag.ToString());
                }
            }
        }
    }

    private void SwitchPicture(string direction)
    {
        Node state = SceneManager.State;
        Photo path = SceneManager.Photos.Find(x => x.Id == state.Main);

        switch (direction)
        {
            case "left":
            {
                if (state.Left != null)
                    state = SceneManager.Nodes.Find(x => x.Main == state.Left);
                break;
            }
            case "right":
            {
                if (state.Right != null)
                    state = SceneManager.Nodes.Find(x => x.Main == state.Right);
                break;
            }
            case "front":
            {
                if (state.Front != null)
                    state = SceneManager.Nodes.Find(x => x.Main == state.Front);
                break;
            }
            case "back":
            {
                if (state.Back != null)
                    state = SceneManager.Nodes.Find(x => x.Main == state.Back);
                break;
            }
            default: break;
        }

        path = SceneManager.Photos.Find(x => x.Id == state.Main);

        SceneManager.State = state;

        Debug.Log(path.Path.ToString());

        Cubemap map = Resources.Load<Cubemap>(path.Path.ToString());

        material.SetTexture("_Tex", map);
    }
}
