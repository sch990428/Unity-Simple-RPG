using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	float _speed = 10.0f;

	Vector3 _destPos;
	Vector3 _inputDir;

	void Start()
    {
		GameManagers.InputManager.KeyAction -= OnKeyboard;
		GameManagers.InputManager.KeyAction += OnKeyboard;
    }

	void UpdateMoving()
	{
		
	}
    void Update()
    {

	}

	void OnKeyboard()
	{
		_inputDir = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
		{
			_inputDir += Vector3.forward;
		}
		if (Input.GetKey(KeyCode.A))
		{
			_inputDir += Vector3.left;
		}
		if (Input.GetKey(KeyCode.S))
		{
			_inputDir += Vector3.back;
		}
		if (Input.GetKey(KeyCode.D))
		{
			_inputDir += Vector3.right;
		}

		if (_inputDir != Vector3.zero)
		{
			_destPos = _inputDir.normalized;
		}
		else
		{
			_destPos = Vector3.zero;
		}

		Vector3 dir = _destPos * _speed * Time.deltaTime;
		transform.Translate(dir, Space.World);

		if (_inputDir != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_inputDir), 20 * Time.deltaTime);
		}
	}
}
