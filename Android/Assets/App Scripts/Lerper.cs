using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Vector2 _goalPosition;
    [SerializeField] private Vector2 _goalRotation;
    [SerializeField] private float _goalScale = 2;
    [SerializeField] private float _speed = 0.5f;
    private float _current, _target;
    public Vector2 _originalPosition = new Vector2(380, 800);
    void Start()
    {
        var lerpValue = Mathf.Lerp(0, 10, 0.5f);
        Debug.Log(lerpValue);
        Debug.Log(_speed);
        _originalPosition = transform.position;
        Debug.Log("Original Position: " + _originalPosition);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
            _target = _target == 0 ? 1 : 0;

        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);
        //Debug.Log(_current);

        transform.position = Vector2.Lerp(_originalPosition, _goalPosition, _curve.Evaluate(_current));

        //transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.position),Quaternion.Euler(_goalRotation), _curve.Evaluate(_current));
    
        transform.localScale = Vector2.Lerp(Vector2.one, Vector2.one * _goalScale, _curve.Evaluate(Mathf.PingPong(_current, 0.5f) * 2));
    }
}
