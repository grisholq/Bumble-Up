using UnityEngine;
using System.Collections.Generic;

public class Step : MonoBehaviour
{
    [SerializeField] private Transform _middle;

    public Transform Middle => _middle;

    public List<Vector3> GetPositionsOnSurface()
    {
        var positions = new List<Vector3>();

        positions.Add(Middle.position);
        positions.Add(Middle.position + Vector3.right);
        positions.Add(Middle.position + Vector3.right * 2);
        positions.Add(Middle.position + Vector3.left);
        positions.Add(Middle.position + Vector3.left * 2);

        return positions;
    }

    public Vector3 GetRandomPositionOnSurface()
    {
        var positions = GetPositionsOnSurface();
        return positions[Random.Range(0, positions.Count)];
    }
}