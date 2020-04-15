using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace : MonoBehaviour
{
    public enum Sides
    {
        Floor = 0,
        WallX = 1,
        WallZ = 2,
        Roof = 3,
        Box = 4
    }
    

    [SerializeField] private Sides side = Sides.Floor;

    public Vector3 GetSideRotation()
    {
        Vector3 angle = new Vector3(0, 0, 0);

        if (side == Sides.WallX)
        {
            angle = new Vector3(270, 90, 90);
        }
        else if (side == Sides.WallZ)
        {
            angle = new Vector3(-90, -90, 0);
        }
        else if (side == Sides.Roof)
        {
            angle = new Vector3(0, 0, 0);
        }

        return angle;
    }
    public Sides Side { get { return side; } }
}
