﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    [Serializable]
    public class PoolPrespawnData
    {
        public GameObject Prefab;
        public int Count;
    }

    public PoolManager poolManager;
    public PoolPrespawnData[] Prespawns;
    public AIManager aiManager;
    public int Score = 0;

    public static GameManager Instance { get; private set; }
    public const float sizeGameGrid = 5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < Prespawns.Length; ++i)
        {
            var prespawn = Prespawns[i];
            poolManager.Prespawn(prespawn.Prefab, prespawn.Count);
        }
    }

    // Update is called once per frame
    void Update () {

	}
}