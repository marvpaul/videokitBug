using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VideoKit;
using System;

public class GetSamples : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        devices = await AudioDevice.Discover();
        foreach (AudioDevice actualAudioDevice in devices)
        {
            if (actualAudioDevice.name.Contains("BuiltIn"))
            {
                audioDevice = actualAudioDevice;
            }
        }


        Camera.main.GetComponent<VideoKitAudioManager>().device = audioDevice;
        Camera.main.GetComponent<VideoKitAudioManager>().OnAudioBuffer += CommitSamples;
        Camera.main.GetComponent<VideoKitAudioManager>().StartRunning();
    }

    private void OnDisable()
    {
        Camera.main.GetComponent<VideoKitAudioManager>().StopRunning(); 
    }

    AudioDevice[] devices;
    AudioDevice audioDevice;

    public void CommitSamples(AudioBuffer audioBuffer)
    {
        float timestamp = audioBuffer.timestamp;
        try
        {
            for (int i = 0; i < audioBuffer.sampleBuffer.Length; i++)
            {
                if (audioBuffer.sampleBuffer[i] > 1f)
                {
                    Debug.Log(i + "audiobuffer " + audioBuffer.sampleBuffer[i]);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Problem while saving sample buffers" + e.Message);
            Debug.Log("Problem while saving sample buffers" + e.StackTrace);

        }
    }
}
