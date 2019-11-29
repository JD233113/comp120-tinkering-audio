using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseToneGenerator : MonoBehaviour
{
    //The GameObject containing the script that inputs desired frequency as an integer (this is set in Unity itself)
    public GameObject freqInputObject;
    public FrequencyInputScript freqInputScript;
    //The GameObject containing the script that inputs desired duration in seconds as an integer (this is set in Unity itself)
    public GameObject durationInputObject;
    public DurationInputScript durationInputScript;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the scripts from the selected GameObjects
        freqInputScript = freqInputObject.GetComponent<FrequencyInputScript>();
        durationInputScript = durationInputObject.GetComponent<DurationInputScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Modified version of the sinewave generator from the workshop slides
    public AudioClip CreateToneAudioClip()
    {
        //Sets the length of the sample to a number of seconds equal to the int returned by the DurationInputScript script
        int sampleDurationSecs = durationInputScript.durationReturned;
        int sampleRate = 44100;
        int sampleLength = sampleRate * sampleDurationSecs;
        float maxValue = 1f / 4f;
        //Sets the frequency to the integer returned by the FrequencyInputScript script
        int frequency = freqInputScript.freqReturned;

        var audioClip = AudioClip.Create("tone", sampleLength, 1, sampleRate, false);

        float[] samples = new float[sampleLength];

        for (var i = 0; i < sampleLength; i++)
        {
            float s = Mathf.Sin(2.0f * Mathf.PI * frequency * ((float)i / (float)sampleRate));
            float v = s * maxValue;
            samples[i] = v;
        }

        audioClip.SetData(samples, 0);
        return audioClip;
    }

    //Used by a button to let the user listen to generated tones before saving
    //Clicking while the tone is already playing will stop it
    public void TogglePlay()
    {
        //Gets the AudioSource from the gameObject that the script is attached to
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource.isPlaying == true)
        {
            audioSource.Stop();
        }
        else
        {
            //Generates the tone and plays it
            audioSource.clip = CreateToneAudioClip();
            audioSource.Play();
        }
    }

    //The same as CreateToneAudioClip but the frequency is halved
    //Used to create contrast between menu forward/back and setting increase/decrease tones
    public AudioClip CreateHalfFreqAudioClip()
    {
        //Sets the length of the sample to a number of seconds equal to the int returned by the DurationInputScript script
        int sampleDurationSecs = durationInputScript.durationReturned;
        int sampleRate = 44100;
        int sampleLength = sampleRate * sampleDurationSecs;
        float maxValue = 1f / 4f;
        //Sets the frequency to the integer returned by the FrequencyInputScript script
        int frequency = freqInputScript.freqReturned / 2;

        var audioClip = AudioClip.Create("tone", sampleLength, 1, sampleRate, false);

        float[] samples = new float[sampleLength];

        for (var i = 0; i < sampleLength; i++)
        {
            float s = Mathf.Sin(2.0f * Mathf.PI * frequency * ((float)i / (float)sampleRate));
            float v = s * maxValue;
            samples[i] = v;
        }

        audioClip.SetData(samples, 0);
        return audioClip;
    }

    //Plays a generated tone that has half the normal frequency
    public void TogglePlayLowFreq()
    {
        //Gets the AudioSource from the gameObject that the script is attached to
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource.isPlaying == true)
        {
            audioSource.Stop();
        }
        else
        {
            //Generates the tone and plays it
            audioSource.clip = CreateHalfFreqAudioClip();
            audioSource.Play();
        }
    }

}