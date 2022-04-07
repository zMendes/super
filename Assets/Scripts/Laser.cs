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
    public Camera VRCamera;
    Vector3 move;
    Vector3 posInit;
    public int maxDistance = 10;
    Vector3 initialScale;
    Transform target;
    CircleMotion motion;
    
    public Vector3 initTransform;
    public Vector3 initTransformObj;

    public int movieRatio;
    
    float currSpeed;

    public enum States {
        Space,
        Time,
        Move
    }

    public States state = States.Move;
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
       // targetObject = e.target.transform;
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
        // Debug.Log(transform.position.x);
    }

    void changeTimeObj(Transform objectToChange){
        return ;

    }



    void Update(){

        if (botao.GetStateDown(trackedObj.inputSource)){
            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance)){
                print("Found an object: " + hit.collider.name);
                posInit = transform.position;
                target = hit.collider.gameObject.transform;
                initialScale = target.localScale;
                pressing = true;
                initTransform = transform.position;
                initTransformObj = hit.collider.gameObject.transform.position;
                state = States.Time;
                motion = hit.collider.gameObject.GetComponent<CircleMotion>();
                currSpeed = motion.angularSpeed;

            }

        }
        if (botao.GetStateUp(trackedObj.inputSource)){
            pressing = false;
        }

        if (pressing){
            Vector3 screenInit = VRCamera.WorldToViewportPoint(new Vector3(posInit.x, posInit.y, posInit.z));
            Vector3 screenNow = VRCamera.WorldToViewportPoint(new Vector3(transform.position.x, transform.position.y, transform.position.z));

            move = (screenNow - screenInit);//.normalize;
            float movement = move.x;
            // Debug.Log("movement: " +movement);
            // Debug.Log("initialScale: " +initialScale);
            // Debug.Log("localScale: " + target.localScale);
            float ratio = 1;
            if (movement > 0)
                ratio = Mathf.Max(1,7 *movement);
            else if (movement < 0)
                ratio = 1/Mathf.Max(1,7*(-movement));
            Debug.Log("Ratio: " + ratio);
            Debug.Log("InitialSpeed" + currSpeed);
            Debug.Log("CurrAngleSpeed" + motion.angularSpeed);
            if (ratio > 5)
                ratio = 5;
            if (ratio < 0.1)
                ratio = 0.1f;
            if (state == States.Space)
                target.localScale = ratio * initialScale;
           if (state == States.Move){
            Vector3 delta = initTransform - transform.position;
            target.position = initTransformObj - (delta * movieRatio);
           }

           if (state == States.Time){
               motion.angularSpeed = ratio * currSpeed;
           }


        //    if (state == States.Time){

        //    }
            
                

        }

    }
 }

