//code from https://forum.unity.com/threads/circular-movement.572797/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Type {
  Circle, 
  Slide,
  Exist
}
public class Motion : MonoBehaviour
{
  public float angularSpeed = 1f;
  public float circleRad = 1f;
 
  public Vector2 fixedPoint;
  private float currentAngle;
  [SerializeField]
  public Type type;

  [SerializeField]
  public Transform pointA;
  [SerializeField]
  public Transform pointB; 
 
void Start ()
{
  fixedPoint = transform.position;

}
 
void Update ()
{
  if (type == Type.Circle){
    currentAngle += angularSpeed * Time.deltaTime; 
    Vector2 offset = new Vector2 (Mathf.Sin (currentAngle), Mathf.Sin (currentAngle)) * circleRad;
    transform.position = fixedPoint + offset;
    }

  else if (type == Type.Slide){
    transform.position = Vector3.Lerp (pointA.position, pointB.position, Mathf.PingPong(Time.time*angularSpeed, 1.0f));
    }
  
  }

}
