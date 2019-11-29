using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTone : MonoBehaviour
{
    public GameObject toneGeneratingObject;
    public BaseToneGenerator toneGeneratorScript;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the tone generating script from the object it is attached to
        toneGeneratorScript = toneGeneratingObject.GetComponent<BaseToneGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Uses the "SavWav" script to save a tone generated via "BaseToneGenerator"
    public void SaveAsWav()
    {
        SavWav.Save("SavedTone", toneGeneratorScript.CreateToneAudioClip());
    }

    //Uses the "SavWav" script to save a tone generated via "BaseToneGenerator", with the frequency halved
    public void SaveLowFreqWav()
    {
        SavWav.Save("SavedLowFreqTone", toneGeneratorScript.CreateHalfFreqAudioClip());
    }
}
