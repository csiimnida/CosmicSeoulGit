using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform player;
    Transform target;
    public float speed = 0.1f;
    private bool isUp;
    void Start()
    {
        target = GetComponent<Transform>();
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, target.position);

        Debug.Log(distance);

        if (distance < 1) StartCoroutine(ElevatorUp());
        if (distance > 1.5f) StartCoroutine(ElevatorDown());
    }

    IEnumerator ElevatorUp()
    {   
        Debug.Log("¿Ã¶ó°©´Ï´Ù.");
        transform.position = Vector2.Lerp(transform.position, Vector2.up * 3f, speed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator ElevatorDown()
    {
        Debug.Log("³»·Á°©´Ï´Ù.");
        transform.position = Vector2.Lerp(transform.position, Vector2.up * -4f, speed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        
    }
}
