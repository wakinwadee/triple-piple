using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    private Plane aimPlane;

    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        aimPlane = new Plane(gameObject.transform.up, gameObject.transform.forward);
    }


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * -Input.GetAxis(VERTICAL) +
                                       Vector3.right * Time.deltaTime * moveSpeed * -Input.GetAxis(HORIZONTAL),
                                       Space.World);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (aimPlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            hitPoint = new Vector3(hitPoint.x, gameObject.transform.position.y, hitPoint.z);
            gameObject.transform.LookAt(hitPoint);
        }
    }


    private void UpdateAnitmatorFlags()
    {

    }

}
