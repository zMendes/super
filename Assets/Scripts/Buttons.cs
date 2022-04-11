using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;
 
public class Buttons : MonoBehaviour
{
    [SerializeField] private AudioSource button_sound;

    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        button_sound.Play();
    }

    public void QuitGame(){
        button_sound.Play();
        Application.Quit();
    }
}
