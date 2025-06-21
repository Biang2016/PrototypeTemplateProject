using System.Collections.Generic;
using BiangLibrary.GamePlay;
using BiangLibrary.ObjectPool;
using BiangLibrary.Singleton;
using UnityEngine;

public class GameObjectPoolManager : TSingletonBaseManager<GameObjectPoolManager>
{
    public enum PrefabNames
    {
        Player,
        DebugPanelColumn,
        DebugPanelButton,
        DebugPanelSlider,
    }

    public Dictionary<PrefabNames, int> PoolConfigs = new Dictionary<PrefabNames, int>
    {
        { PrefabNames.Player, 1 },
        { PrefabNames.DebugPanelColumn, 4 },
        { PrefabNames.DebugPanelButton, 4 },
        { PrefabNames.DebugPanelSlider, 4 },
    };

    public Dictionary<PrefabNames, GameObjectPool> PoolDict = new Dictionary<PrefabNames, GameObjectPool>();
    public Dictionary<string, GameObjectPool> FXDict = new Dictionary<string, GameObjectPool>();
    public Dictionary<string, GameObjectPool> ProjectileDict = new Dictionary<string, GameObjectPool>();

    private Transform Root;

    public void Init(Transform root)
    {
        Root = root;
    }

    public bool IsInit = false;

    public override void Awake()
    {
        IsInit = true;
        foreach (KeyValuePair<PrefabNames, int> kv in PoolConfigs)
        {
            string prefabName = kv.Key.ToString();
            GameObject go_Prefab = PrefabManager.Instance.GetPrefab(prefabName);
            if (go_Prefab)
            {
                GameObject go = new GameObject("Pool_" + prefabName);
                GameObjectPool pool = go.AddComponent<GameObjectPool>();
                pool.transform.SetParent(Root);
                PoolDict.Add(kv.Key, pool);
                PoolObject po = go_Prefab.GetComponent<PoolObject>();
                pool.Initiate(po, kv.Value);
            }
        }

        IsInit = true;
    }

    public void OptimizeAllGameObjectPools()
    {
        foreach (KeyValuePair<PrefabNames, GameObjectPool> kv in PoolDict)
        {
            kv.Value.OptimizePool();
        }
    }
}