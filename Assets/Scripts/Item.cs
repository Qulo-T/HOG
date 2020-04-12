using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool small;
    private EmptySpace space;

    public void Start()
    {
        
    }

    public void ItemRotate()
    {
        space = transform.parent.GetComponent<EmptySpace>();
        Vector3 angle = space.GetSideRotation();
        //transform.Rotate(angle);
        transform.rotation = Quaternion.Euler(angle);
    }
}
