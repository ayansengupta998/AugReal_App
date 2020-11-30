using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RGBController : MonoBehaviour
{
    public Slider slider;
    float sliderValue;
    string hue = 0.0.ToString();

    void Update()
    {
        sliderValue = slider.value;
        hue = sliderValue.ToString();
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
        form.AddField("arg", hue);
        Dictionary<string, string> headers = form.headers;
        byte[] rawData = form.data;
        string url = "https://api.particle.io/v1/devices/e00fce687482c84d64198d35/turnOn";

        // Add a custom header to the request.
        // In this case a basic authentication to access a password protected resource.
        headers["Authorization"] = "Bearer fcf969bc484a3874d9022d5b2cbeeb97b537fb2f";

        // Post a request to an URL with our custom headers
        using (WWW www = new WWW(url, rawData, headers))
        {
            yield return www;
            //.. process results from WWW request here...
        }
    }
}