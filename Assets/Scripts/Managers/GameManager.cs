using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
	static GameManagers s_GameManager;
	static GameManagers GameManager { get { Init(); return s_GameManager; } }

	InputManager _inputManager = new InputManager();
	public static InputManager InputManager { get { return GameManager._inputManager; } }
	void Start()
	{
		Init();
	}

	void Update()
	{
		_inputManager.OnUpdate();
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
