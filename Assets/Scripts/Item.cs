using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool floor;
    [SerializeField] private bool wall;
    [SerializeField] private bool roof;
    [SerializeField] private bool box;

    private EmptySpace _space;

    public void ItemRotate()
    {
        _space = transform.parent.GetComponent<EmptySpace>();
        Vector3 angle = _space.GetSideRotation();        
        transform.rotation = Quaternion.Euler(angle);
    }

    public bool Floor { get {return floor; } }
    public bool Wall { get { return wall; } }
    public bool Roof { get { return roof; } }
    public bool Box { get { return box; } }

}
