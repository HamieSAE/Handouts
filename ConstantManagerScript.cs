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
		IF(Instance == null)
		{
			Instance = this;
			DontDestroyonLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
}