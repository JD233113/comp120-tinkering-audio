using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationInputScript : MonoBehaviour
{
    //The desired length of a tone in seconds, set via the UI
    public Text durationSecs;
    public int durationReturned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ReturnLength()
    {
        //Converts the text of "durationSecs" into a float and returns it for use in the tone generator
        durationReturned = int.Parse(durationSecs.text);
        return durationReturned;
    }

    public void SetLength()
    {
        //"durationSecs" is set to the contents of the GameObject's text input field
        //"durationSecs" is then converted to a float and is returned as "durationReturned" by the ReturnLength() function
        durationSecs = GetComponent<Text>();
        ReturnLength();
    }
}
