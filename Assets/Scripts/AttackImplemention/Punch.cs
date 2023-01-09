using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerCharacter>()?.Hit(Random.Range(10, 25));
    }
}
