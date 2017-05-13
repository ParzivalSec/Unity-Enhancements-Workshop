using UnityEngine;
using System.Collections;


public class SpawnInfo
{
    public SpawnInfo(Vector3 position, Vector3 direction)
    {
        this.position = position;
        this.direction = direction;
    }
    public Vector3 position;
    public Vector3 direction;
}
