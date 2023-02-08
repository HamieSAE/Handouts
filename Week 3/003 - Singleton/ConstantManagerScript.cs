using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ConstantManagerScript : MonoBehaviour
{
	public static ConstantManagerScript Instance
	{
		get;
		private set;
	}

	public int Value;

	private void Awake()
	{
		iF(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
}