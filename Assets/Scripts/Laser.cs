using System.Collections;

using System.Collections.Generic;

using UnityEngine;


using UnityEngine.EventSystems;

using Valve.VR.Extras;


public class Laser : MonoBehaviour

{

     private SteamVR_LaserPointer steamVrLaserPointer;

    private bool clicked = false;
    private bool pressing = false;

     private void Awake()

     {

         steamVrLaserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

         steamVrLaserPointer.PointerIn += OnPointerIn;

         steamVrLaserPointer.PointerOut += OnPointerOut;

         steamVrLaserPointer.PointerClick += OnPointerClick;

     }

 

     private void OnPointerClick(object sender, PointerEventArgs e)

     {

         clicked = true;
         scaleObj(e.target.transform);
         //StartCoroutine(MoveFromTo(e.target.transform, e.target.transform.position, transform.position, 8.0f));



     }

 

     private void OnPointerOut(object sender, PointerEventArgs e)

     { 
         pressing = false;

        // Debug.Log("laser saiu do objeto " + e.target.name);

        return;
     }

 

     private void OnPointerIn(object sender, PointerEventArgs e)

     {

        //  Debug.Log("laser entrou do objeto " + e.target.name);
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

        if (clicked){
            pressing = true;
            clicked = false;
            posInit = transform.position.x;

        }
        if (pressing){
            
        }
    }
 }

