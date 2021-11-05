using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float rightSide = 3f;
    public static float leftSide = -3f;

    public float internalLeft;
    public float internalRight;

    void Update()
    {
        internalRight = rightSide;
        internalLeft = leftSide;

    }
}
