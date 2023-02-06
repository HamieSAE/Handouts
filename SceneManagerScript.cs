using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
	public Text TextonValue;

	private void Start()
	{
		TextonValue.text = ConstantManagerScript.Instance.Value.Tostring();
	}

	public void GoToFirstScene()
	{
		SceneManager.LoadScene("first");
		ConstantManagerScript.Instance.Value++;
	}

	public void GoToSecondScene()
	{
		SceneManager.LoadScene("second");
		ConstantManagerScript.Instance.Value++;
	}
	
}