using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper_Ball : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    public EnermyDataSO enermyData;

    private Rigidbody2D rigidbody2D;
    private Animator _animator;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }



    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
        _animator.Play("Move");
    }

    public void Rotate()
    {
        rigidbody2D.velocity = ((Mathf.Approximately(transform.eulerAngles.y, 180)) ? Vector2.right : Vector2.left) * 2;

    }

    public void Push()
    { 
        PoolManager.Instance.Push(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage(enermyData, enermyData.AttackPower);
            _animator.Play("Die");
        }
    }
}