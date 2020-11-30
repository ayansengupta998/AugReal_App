using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class yellow : MonoBehaviour
{
    public void open()
    {
        StartCoroutine(Start());
    }
    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("arg", "0.2");
        Dictionary<string, string> headers = form.headers;
        byte[] rawData = form.data;
        string url = "https://api.particle.io/v1/devices/e00fce6838d1a3c43e80cd3c/turnOn";

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