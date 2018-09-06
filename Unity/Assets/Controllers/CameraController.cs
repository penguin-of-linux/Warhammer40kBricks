using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    //private float speed = 5;

    private const KeyCode LeftKey = KeyCode.LeftArrow;
    private const KeyCode RightKey = KeyCode.RightArrow;
    private const KeyCode UpKey = KeyCode.UpArrow;
    private const KeyCode DownKey = KeyCode.DownArrow;

    private const KeyCode RotCamXKey1 = KeyCode.Q;
    private const KeyCode RotCamXKey2 = KeyCode.E;
    private const KeyCode RotCamYKey1 = KeyCode.Z;
    private const KeyCode RotCamYKey2 = KeyCode.C;

    private const float MaxHeight = 55;
    private const float MinHeight = 5;

    //private const int XRotationLimit = 240;
    private const int YRotationLimit = 90;

    private const int MovingSpeedChange = 15;
    private const int RotationSpeedChange = 3;
    private const int HeightSpeedChange = 3;

    private float _camRotationX;
    private float _camRotationY;
    private float _tempHeight;
    private float _height;
    private bool _leftRotation, _rightRotation, _upMoving, _downMoving;

    void Start()
    {
        _tempHeight = _height = (MaxHeight + MinHeight) / 2;
        _camRotationX = 0;
        _camRotationY = YRotationLimit / 2;
        transform.position = new Vector3(0, _height, 0);
    }

    public void CursorTriggerEnter(string triggerName)
    {
        switch (triggerName)
        {
            case "L":
                _leftRotation = true;
                break;
            case "R":
                _rightRotation = true;
                break;
            case "U":
                _upMoving = true;
                break;
            case "D":
                _downMoving = true;
                break;
        }
    }

    public void CursorTriggerExit(string triggerName)
    {
        switch (triggerName)
        {
            case "L":
                _leftRotation = false;
                break;
            case "R":
                _rightRotation = false;
                break;
            case "U":
                _upMoving = false;
                break;
            case "D":
                _downMoving = false;
                break;
        }
    }

    void Update()
    {
        var xmoving = 0;
        if (Input.GetKey(LeftKey) || _leftRotation) xmoving = -MovingSpeedChange;
        else if (Input.GetKey(RightKey) || _rightRotation) xmoving = MovingSpeedChange;

        var zmoving = 0;
        if (Input.GetKey(DownKey) || _downMoving) zmoving = -MovingSpeedChange;
        else if (Input.GetKey(UpKey) || _upMoving) zmoving = MovingSpeedChange;

        if (Input.GetKey(RotCamXKey2)) _camRotationX -= RotationSpeedChange;
        else if (Input.GetKey(RotCamXKey1)) _camRotationX += RotationSpeedChange;
        //_camRotationX = Mathf.Clamp(_camRotationX, 0, XRotationLimit);

        if (Input.GetKey(RotCamYKey2)) _camRotationY -= RotationSpeedChange;
        else if (Input.GetKey(RotCamYKey1)) _camRotationY += RotationSpeedChange;
        _camRotationY = Mathf.Clamp(_camRotationY, 0, YRotationLimit);

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_height < MaxHeight) _tempHeight += HeightSpeedChange;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_height > MinHeight) _tempHeight -= HeightSpeedChange;
        }

        _tempHeight = Mathf.Clamp(_tempHeight, MinHeight, MaxHeight);
        _height = Mathf.Lerp(_height, _tempHeight, RotationSpeedChange * Time.deltaTime);

        Vector3 direction = new Vector3(xmoving, 0, zmoving);
        transform.Translate(direction * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, _height, transform.position.z);
        transform.rotation = Quaternion.Euler(_camRotationY, _camRotationX, 0);
    }
}