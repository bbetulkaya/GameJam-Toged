using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    public float damageValue;
    public float damageImpact;
    public string obstacleName;
    void Start()
    {
        obstacleName = this.gameObject.name;
    }
}
