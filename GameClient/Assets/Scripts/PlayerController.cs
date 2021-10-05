using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    const string OBSTRUCTION = "Obstruction";

    private Plane aimPlane;
    private Rigidbody ownRigidbody;

    private CharacterController ownController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    public float playerSpeed = 2.0f;
    public float punchForce = 10f;



    // Start is called before the first frame update
    void Start()
    {
        aimPlane = new Plane(gameObject.transform.up, gameObject.transform.forward);
        ownRigidbody = gameObject.GetComponent<Rigidbody>();
        ownController = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {

        groundedPlayer = ownController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
            ownController.Move(playerVelocity * Time.deltaTime);
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        ownController.Move(move * Time.deltaTime * -playerSpeed);

       if (move != Vector3.zero)
       {
           gameObject.transform.forward = move;
       }

        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (aimPlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            hitPoint = new Vector3(hitPoint.x, gameObject.transform.position.y, hitPoint.z);
            gameObject.transform.LookAt(hitPoint);
        }
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Debug.Log(hit.gameObject.name.ToString());
    //    if(hit.gameObject.CompareTag(OBSTRUCTION))
    //    {
    //        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
    //        Vector3 punchVelocity = pushDir * -1 * punchForce;
    //        ownController.SimpleMove(punchVelocity * Time.deltaTime);
    //    }
    //}

    private void UpdateAnitmatorFlags()
    {

    }

}
