﻿using BiangLibrary.Singleton;
using UnityEngine;

public class FXManager : TSingletonBaseManager<FXManager>
{
    private Transform Root;

    public void Init(Transform root)
    {
        Root = root;
    }

    public FX PlayFX(string fxName, Vector3 position, float scale = 1.0f)
    {
        FX fx = GameObjectPoolManager.Instance.FXDict[fxName].AllocateGameObject<FX>(Root);
        fx.transform.position = position;
        fx.transform.localScale = Vector3.one * scale;
        fx.transform.rotation = Quaternion.identity;
        fx.Play();
        return fx;
    }
}