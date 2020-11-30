using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Temperature_Text : MonoBehaviour
{
	public double TemperatureInput;
	double temp;
	string path;
	string Url;
	string jsonRate;
	WWW www;


	void Start() // Use this for initialization
	{

	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string work = www.text;

			_Particle fields = JsonUtility.FromJson<_Particle>(work);
			string jsonRate = fields.result;

			temp = double.Parse(jsonRate);
			//TemperatureInput = Mathf.FloorToInt(temp);
			TemperatureInput = temp;
			//Debug.Log (TemperatureInput);
		}
		else
		{

		}
	}

	// Update is called once per frame
	void Update()
	{

		//heartrate = GameBeat.GetComponent<IoT>().heartrate;
		string url = "https://api.particle.io/v1/devices/e00fce687482c84d64198d35/Temperature?access_token=fcf969bc484a3874d9022d5b2cbeeb97b537fb2f";
		www = new WWW(url);
		StartCoroutine(WaitForRequest(www));

		GetComponent<TextMesh>().text = TemperatureInput.ToString("f1") + "° C";


	}

	[System.Serializable]
	public class _Particle
	{
		public string name;
		public string result;
	}


}