using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrequencyInputScript : MonoBehaviour
{
    public Text freq;
    public int freqReturned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public int ReturnFreq()
    {
        //Converts the text of "freq" into an integer and returns it for use in the tone generator
        freqReturned = int.Parse(freq.text);
        return freqReturned;
    }

    public void SetFreq()
    {
        //"freq" is set to the contents of the GameObject's text input field
        //"freq" is then converted to an integer by the ReturnFreq() function and is returned as "freqReturned"
        freq = GetComponent<Text>();
        ReturnFreq();
    }
}
