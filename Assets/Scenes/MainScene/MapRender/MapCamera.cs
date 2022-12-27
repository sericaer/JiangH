using JiangH.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

class MapCamera : MonoBehaviour
{
    public new Camera camera;

    public UnityEvent OnMoved;
    public Tilemap tilemap;

    public void MoveTo(Coordinate coord)
    {
        var newPos = tilemap.CellToWorld(new Vector3Int(coord.x, coord.y));
        camera.transform.position = new Vector3(newPos.x, newPos.y, camera.transform.position.z);
        OnMoved.Invoke();
    }

    public void MoveTo(Vector3 vector3)
    {
        camera.transform.position += vector3;
    }
}