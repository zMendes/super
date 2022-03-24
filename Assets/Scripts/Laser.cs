using System.Collections;

using System.Collections.Generic;

using UnityEngine;


using UnityEngine.EventSystems;

using Valve.VR.Extras;

using Valve.VR;


public class Laser : MonoBehaviour

{

    private SteamVR_LaserPointer steamVrLaserPointer;
    [SerializeField] private SteamVR_Action_Boolean botao = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    SteamVR_Behaviour_Pose trackedObj;


    // private bool clicked = false;
    private bool pressing = false;
    public GameObject VRCamera;
    Vector3 move;
    Vector3 posInit;

    Transform targetObject;
     private void Start()

     {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();


        steamVrLaserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

        steamVrLaserPointer.PointerIn += OnPointerIn;

        steamVrLaserPointer.PointerOut += OnPointerOut;

        steamVrLaserPointer.PointerClick += OnPointerClick;

     }

 

     private void OnPointerClick(object sender, PointerEventArgs e)

     {
        targetObject = e.target.transform;
        print("got it");
         //scaleObj(e.target.transform);
         //StartCoroutine(MoveFromTo(e.target.transform, e.target.transform.position, transform.position, 8.0f));



     }

 

     private void OnPointerOut(object sender, PointerEventArgs e){

        return;
     }

 

     private void OnPointerIn(object sender, PointerEventArgs e)

     {
        return;

     }

    IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed)

    {

        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;

        float t = 0;

        while (t <= 1.0f)

        {

            t += step;

            objectToMove.position = Vector3.Lerp(a, b, t);

            yield return new WaitForFixedUpdate();

        }

        objectToMove.position = b;

    }

    void scaleObj(Transform objectToScale){
        objectToScale.localScale = 2 * objectToScale.localScale;
        Debug.Log(transform.position.x);
    }


    void Update(){

        if (botao.GetStateDown(trackedObj.inputSource)){
            pressing = true;
            posInit = transform.position;

        }
        if (botao.GetStateUp(trackedObj.inputSource)){
            pressing = false;
        }

        if (pressing){
            move = VRCamera.transform.rotation * new Vector3(transform.position.x-posInit.x, transform.position.z-posInit.z, transform.position.y-posInit.y);
            print(move);
            //targetObject.transform.localScale = move.x *
        }

    }
 }

