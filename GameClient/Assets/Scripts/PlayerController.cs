using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float punchForce = 10f;
    public GameObject playerWeapon;
    public GameObject playerArmor;
    public GameObject playerItem;

    private Plane aimPlane;
    private Rigidbody ownRigidbody;
    private CharacterController ownController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private IngameInventory playerInventory;

    // 	Awake is called when the script instance is being loaded.
    private void Awake()
    {
        playerInventory = new IngameInventory();
        playerWeapon = Instantiate(playerWeapon);
        playerWeapon.transform.position = gameObject.transform.Find(Constants.R_WEAPON_POINT).position;
        playerWeapon.transform.forward = gameObject.transform.Find(Constants.R_WEAPON_POINT).forward;
        playerWeapon.transform.parent = gameObject.transform.Find(Constants.R_WEAPON_POINT);
        playerInventory.ingameWeapon = playerWeapon.GetComponent<Weapon>();
        
        //Instantiate(playerWeapon,
        //            gameObject.transform.Find(Constants.R_WEAPON_POINT).position,
        //            gameObject.transform.Find(Constants.R_WEAPON_POINT).rotation);
    }


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

         Vector3 move = new Vector3(Input.GetAxis(Constants.HORIZONTAL), 0, Input.GetAxis(Constants.VERTICAL));
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

        
            playerInventory.ingameWeapon.Action(gameObject);
        
    }


    private void UpdateAnitmatorFlags()
    {

    }

}
