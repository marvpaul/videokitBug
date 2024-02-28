using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VideoKit; 
public class Recorder : MonoBehaviour
{
    public void StartRecording(){
        this.GetComponent<VideoKitRecorder>().StartRecording(); 
    }
}
