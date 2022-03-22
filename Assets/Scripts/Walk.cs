using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using Valve.VR;

using Valve.VR.InteractionSystem;


public class Walk : MonoBehaviour

{


    [SerializeField]
    private GameObject VRCamera;
    private CharacterController controller;

    private Vector3 playerVelocity;


    private bool groundedPlayer;

    public float playerSpeed = 2.0f;

    private float gravityValue = -9.81f;


    public SteamVR_Action_Boolean teleportAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");


    public SteamVR_ActionSet actionSet;


    public SteamVR_Action_Vector2 moveAction;

   

    public SteamVR_Input_Sources hand;


    private void Start()

    {

        controller = gameObject.GetComponent<CharacterController>();

        actionSet.Activate(hand);

    }


    void Update()

    {

        if (teleportAction.lastState)
            return;

        // Posição do gamepad

        Vector2 m = moveAction[hand].axis;

       

        groundedPlayer = controller.isGrounded;

       

        if (groundedPlayer && playerVelocity.y < 0)

        {

            playerVelocity.y = 0f;

        }


        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        Vector3 move = VRCamera.transform.rotation * new Vector3(m.x, 0, m.y);
        move.y = 0f;
        //transform.position = transform.position + move * Time.deltaTime * playerSpeed;
        controller.Move(move *playerSpeed* Time.deltaTime);


    }

}
