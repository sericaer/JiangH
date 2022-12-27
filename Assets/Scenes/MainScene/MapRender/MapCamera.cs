using JiangH.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

class MapCamera : MonoBehaviour
{
    public new Camera camera;
    public Tilemap tilemap;

    public void MoveTo(Coordinate coord)
    {
        var newPos = tilemap.CellToWorld(new Vector3Int(coord.x, coord.y));
        camera.transform.position = new Vector3(newPos.x, newPos.y, camera.transform.position.z);
    }

    public void MoveTo(Vector3 vector3)
    {
        Vector3 currentVelocity = Vector3.zero;
        camera.transform.position = Vector3.SmoothDamp(camera.transform.position, camera.transform.position + vector3, ref currentVelocity, 0.05f);
    }
}