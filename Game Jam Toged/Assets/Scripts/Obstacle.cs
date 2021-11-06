using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    public float damageValue;
    public string obstacleName;

    void Start()
    {
        obstacleName = this.gameObject.name;
    }
}
