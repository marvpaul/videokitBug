using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VideoKit; 
public class Recorder : MonoBehaviour
{
    public void StartRecording(){
        if (GetComponent<VideoKitRecorder>().status == VideoKitRecorder.Status.Recording){

        this.GetComponent<VideoKitRecorder>().StopRecording(); 
        } else {
        this.GetComponent<VideoKitRecorder>().StartRecording(); 
        }
    }

    public async void StopRecording(MediaAsset asset)
    {
        var recordingPath = asset.path;
        Debug.Log(recordingPath);
    }
}
