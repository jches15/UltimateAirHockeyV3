using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMSounds : MonoBehaviour
{
   public AudioSource Menu;

   public void PlayMenu(){
       Menu.Play();
       Debug.Log("HEREEEE");
   }
}
