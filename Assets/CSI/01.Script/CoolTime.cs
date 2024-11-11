using System.Collections;
using UnityEngine;

public abstract class CoolTime : MonoBehaviour
{
    protected CoolTime coolTime;
    public IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Do();
    }

    protected virtual void Do()
    {
        
    }
}
