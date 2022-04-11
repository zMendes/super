using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Laser power;

    [SerializeField] private AudioSource button_sound;

    void Start()
    {
        
    }

    public void SizeClick(){
        Debug.Log("Size");
        button_sound.Play();
        power.state = States.Space;

    }
    public void TimeClick(){
        Debug.Log("Time");
        button_sound.Play();
        power.state = States.Time;
    }
    public void MoveClick(){
        Debug.Log("Move");
        button_sound.Play();
        power.state = States.Move;

    }
}
