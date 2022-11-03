using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosBotones : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;

    public void playButton1() { 
        audio1.Play();
    }
    public void playButton2()
    {
        audio2.Play();
    }
}
