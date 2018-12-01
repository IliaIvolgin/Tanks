﻿using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour {
    public float speed = 1f;
    public Vector3 moveEnd;
    public bool dieAfterFinish;

    private Vector3 _moveStart;
    private Rigidbody _rigidbody;
    private float _lifeTime = 0;
    private float _flyTime = 1f;
    private bool _moved = true;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveStart = transform.position;
        if (_moved && moveEnd!=null)
        {
            MoveTo(_moveStart, moveEnd);
        }
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody is null");
        }
    }

    public void OnEnable()
    {
        _moveStart = transform.position;
        _moved = true;
    }

    public void FixedUpdate()
    {
        _lifeTime += Time.fixedDeltaTime;
        if (_moved && _moveStart!=null && moveEnd!=null)
        {
            _rigidbody.transform.position = Vector3.Lerp(_moveStart, moveEnd, _lifeTime / _flyTime);
            if (_lifeTime > _flyTime)
            {
                _moved = false;
                if (dieAfterFinish)
                {
                    Destroy(this);
                }
            }
        }
    }

    public void MoveTo(Vector3 moveStart, GameObject moveEnd)
    {
        MoveTo(moveStart, moveEnd.transform.position);
    }

    public void MoveTo(Vector3 moveStart, Vector3 moveEnd)
    {
        _lifeTime = 0;
        _moveStart = moveStart;
        this.moveEnd = moveEnd;
        float dist = Vector3.Distance(moveStart, moveEnd);
        _flyTime = dist / speed;
        _moved = true;
    }
}
