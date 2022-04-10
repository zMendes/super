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
        power.state = States.Space;

    }
    public void TimeClick(){
        power.state = States.Time;
    }
    public void MoveClick(){
        power.state = States.Move;

    }
}
