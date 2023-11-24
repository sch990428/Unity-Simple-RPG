using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
	static GameManagers s_GameManager;
	public static GameManagers GameManager { get { Init(); return s_GameManager; } }
	void Start()
	{
		Init();
	}

	void Update()
	{
		
	}

	static void Init()
	{
		if (s_GameManager == null)
		{
			GameObject go = GameObject.Find("@GameManagers");

			if (go == null)
			{ 
				go = new GameObject { name = "@GameManagers" }; 
				go.AddComponent<GameManagers>();
			}

			DontDestroyOnLoad(go);
			s_GameManager = go.GetComponent<GameManagers>();
		}
	}
}
