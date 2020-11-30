using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RangeFinder : MonoBehaviour
{
    public Slider slider;
    float sliderValue;
    string range = 0.0.ToString();

    void Update()
    {
        sliderValue = slider.value;
        range = sliderValue.ToString();
        StartCoroutine(Post());
    }
    public void OnhSliderChanged()
    {
        Debug.Log(slider.value);
    }

    IEnumerator Post()
    {
        yield return new WaitForSeconds(15);
        WWWForm form = new WWWForm();
        form.AddField("arg", range);
        Dictionary<string, string> headers = form.headers;
        byte[] rawData = form.data;
        string url = "https://api.particle.io/v1/devices/e00fce6838d1a3c43e80cd3c/rangeFinder";

        // Add a custom header to the request.
        // In this case a basic authentication to access a password protected resource.
        headers["Authorization"] = "Bearer db5238fdd13f23ad65d2e7a9ab74c8dc29a79f20";

        // Post a request to an URL with our custom headers
        using (WWW www = new WWW(url, rawData, headers))
        {
            yield return www;
            //.. process results from WWW request here...
        }
    }
}