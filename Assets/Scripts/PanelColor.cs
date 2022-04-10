 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class PanelColor : MonoBehaviour {
     [SerializeField]
     public Color color;
     // Use this for initialization
     void Start () {
         Image img =  GetComponent<Image>();
         img.color = color ;//new Color(0.1f, 0.1f, 0.1f, .9f);
     }
 
 }