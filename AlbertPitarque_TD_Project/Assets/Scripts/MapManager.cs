using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    static public MapProperties Map0()
    {
        MapProperties newMap = new MapProperties();
        newMap.idTile = new List<List<int>>();

        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 04, 02, 02, 02, 03, 07, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 07, 07, 00, 07, 07, 07, 07, 00, 01, 00, 07, 00, 01, 07, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 04, 02, 02, 03, 00, 07, 07, 07, 01, 07, 07, 07, 01, 07, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 01, 00, 00, 01, 07, 07, 00, 00, 01, 07, 07, 00, 01, 00, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 00, 01, 07, 07, 01, 00, 00, 04, 02, 05, 07, 07, 07, 01, 07, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 01, 07, 00, 06, 02, 02, 05, 00, 07, 00, 07, 00, 01, 00, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 00, 00, 01, 00, 07, 00, 07, 00, 07, 07, 07, 07, 07, 07, 06, 02, 02, 02, 07 });
        newMap.idTile.Insert(0, new List<int>() { 02, 02, 02, 05, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 00, 07, 00, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 00, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07 });
        newMap.idTile.Insert(0, new List<int>() { 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07, 07 });

        newMap.corners = new List<Vector2>();
        newMap.corners.Add(new Vector2(1, 2));
        newMap.corners.Add(new Vector2(3, 2));
        newMap.corners.Add(new Vector2(3, 7));
        newMap.corners.Add(new Vector2(6, 7));
        newMap.corners.Add(new Vector2(6, 4));
        newMap.corners.Add(new Vector2(9, 4));
        newMap.corners.Add(new Vector2(9, 5));
        newMap.corners.Add(new Vector2(11, 5));
        newMap.corners.Add(new Vector2(11, 9));
        newMap.corners.Add(new Vector2(15, 9));
        newMap.corners.Add(new Vector2(15, 3));
        newMap.corners.Add(new Vector2(18, 3));

        newMap.idEnemy = new List<List<Vector2>>();
        newMap.idEnemy.Add(new List<Vector2>() //Primera oleada
        {
            new Vector2(0, 5), //Id=0, tiempo =5
            new Vector2(0, 1),
            new Vector2(0, 3),
            new Vector2(2, 2)
        });
        newMap.idEnemy.Add(new List<Vector2>() //Segunda oleada
        {
            new Vector2(0, 5), //Id=0, tiempo =5
            new Vector2(0, 2),
            new Vector2(1, 1),
            new Vector2(0, 2),
            new Vector2(0, 1)
        });
        newMap.idEnemy.Add(new List<Vector2>() //Segunda oleada
        {
            new Vector2(1, 5), //Id=0, tiempo =5
            new Vector2(3, 1),
            new Vector2(4, 3),
            new Vector2(2, 1),
            new Vector2(0, 2),
            new Vector2(0, 1),
            new Vector2(0, 1),
            new Vector2(3, 1),
            new Vector2(4, 1),
            new Vector2(4, 1)
        });
        newMap.idEnemy.Add(new List<Vector2>() //Segunda oleada
        {
            new Vector2(4, 1), //Id=0, tiempo =5
            new Vector2(3, 1),
            new Vector2(4, 3),
            new Vector2(3, 1),
            new Vector2(4, 2),
            new Vector2(4, 1),
            new Vector2(1, 1),
            new Vector2(5, 1),
            new Vector2(4, 1),
            new Vector2(3, 1)
        });
        newMap.idEnemy.Add(new List<Vector2>() //Segunda oleada
        {
            new Vector2(3, 1), //Id=0, tiempo =5
            new Vector2(3, 1),
            new Vector2(3, 3),
            new Vector2(4, 1),
            new Vector2(4, 2),
            new Vector2(4, 1),
            new Vector2(1, 1),
            new Vector2(5, 1),
            new Vector2(4, 1),
            new Vector2(4, 1), 
            new Vector2(4, 1),
            new Vector2(1, 3),
            new Vector2(3, 1),
            new Vector2(4, 2),
            new Vector2(5, 1),
            new Vector2(3, 1),
            new Vector2(2, 1),
            new Vector2(5, 1),
            new Vector2(3, 1)
        });
        return newMap;
    }
    

}
