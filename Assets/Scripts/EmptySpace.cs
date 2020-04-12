using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace : MonoBehaviour
{
    public enum SideAxes
    {
        Floor = 0,
        WallX = 1,
        WallZ = 2,
        Roof = 3
    }

    [SerializeField] private SideAxes axes = SideAxes.Floor;

    public Vector3 GetSideRotation()
    {
        Vector3 angle = new Vector3(0, 0, 0);

        if (axes == SideAxes.WallX)
        {
            angle = new Vector3(270, 90, 90);
        }
        else if (axes == SideAxes.WallZ)
        {
            angle = new Vector3(-90, -90, 0);
        }
        else if (axes == SideAxes.Roof)
        {
            angle = new Vector3(0, 0, 0);
        }

        return angle;
    }
}
