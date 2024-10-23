using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Stack<IPoolable> _pool;
    private Transform _parentTrm;
    private IPoolable _poolable; // 풀링하고 있는 클래스
    private GameObject _prefab; // 만들 프리팹

    public Pool(IPoolable poolable, Transform parent, int count)
    {
        _pool = new Stack<IPoolable>(count);
        _parentTrm = parent;
        _poolable = poolable;
        _prefab = poolable.ObjectPrefab;

        for (int i = 0; i < count; i++)
        {
            GameObject gameObj = GameObject.Instantiate(_prefab, _parentTrm);
            gameObj.SetActive(false);
            gameObj.name = _poolable.PoolName;
            IPoolable item = gameObj.GetComponent<IPoolable>();
            _pool.Push(item);
        }
    }

    public IPoolable Pop()
    {
        IPoolable item = null;

        if (_pool.Count == 0)
        {
            GameObject gameObj = GameObject.Instantiate(_prefab, _parentTrm);
            gameObj.name = _poolable.PoolName;
            item = gameObj.GetComponent<IPoolable>();
        }
        else
        {
            item = _pool.Pop();
            item.ObjectPrefab.SetActive(true);
        }
        return item;
    }

    public void Push(IPoolable item)
    {
        item.ObjectPrefab.SetActive(false);
        _pool.Push(item);
    }
}
