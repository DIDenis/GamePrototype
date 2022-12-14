using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Item
{
    ///<summary>Время, необходимое для проигрывания анимации сброса предмета на базу</summary>
    ///<value>[0, infinity]</value>
    [SerializeField, Min(0), 
    Tooltip("Время, необходимое для проигрывания анимации сброса предмета на базу. [0, infinity]")] 
    float collectionTime = 3;

    public override void DestroyItem()
    {
        trigger.enabled = false;
        StartCoroutine(DestroyThis());
    }

    public override void Drop(Vector3 force, Vector3 torque = default)
    {
        trigger.enabled = true;
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    public void Collect()
    {
        trigger.enabled = false;
        rb.isKinematic = true;
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(collectionTime);
        ObjectsPool<Money>.Push(this);
    }
}
