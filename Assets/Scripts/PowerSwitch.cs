using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Laser power;

    
    void Start()
    {
        
    }

    public void SizeClick(){
        Debug.Log("Size");
        power.state = States.Space;

    }
    public void TimeClick(){
        Debug.Log("Time");
        power.state = States.Time;
    }
    public void MoveClick(){
        Debug.Log("Move");
        power.state = States.Move;

    }
}
