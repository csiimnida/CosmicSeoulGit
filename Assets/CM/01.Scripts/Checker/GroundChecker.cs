using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckerTrm;
    [SerializeField] private Vector2 _checkerSize;

    [SerializeField] private LayerMask _whatIsGround;
    [field: SerializeField] public bool IsGround { get; private set; }


    public void CheckGround()
    {
        Vector3 position = _groundCheckerTrm.position;
        Collider2D collider = Physics2D.OverlapBox(position, _checkerSize, 0, _whatIsGround);
        IsGround = collider != null;
    }

    private void Update()
    {
        CheckGround();
    }

    private void OnDrawGizmos()
    {
        if (_groundCheckerTrm == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundCheckerTrm.position, _checkerSize);
        Gizmos.color = Color.white;
    }
}
