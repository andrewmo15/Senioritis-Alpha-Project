using System;
using System.Linq;
using UnityEngine;

public class AreaReporter : MonoBehaviour
{
    // Returns the current area of the map that the GameObject is in

    public enum Area
    {
        Room1,
        Room2,
        Room3,
        Room4,
        Hallway
    }

    public Area _CurrentArea;
    public Area CurrentArea
    {
        get
        {
            return _CurrentArea;
        }
        set
        {
            _CurrentArea = value;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (Area area in Enum.GetValues(typeof(Area)).Cast<Area>())
        {
            if (collision.gameObject.CompareTag(area.ToString()))
            {
                _CurrentArea = area;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (Area area in Enum.GetValues(typeof(Area)).Cast<Area>())
        {
            if (other.gameObject.CompareTag(area.ToString()))
            {
                _CurrentArea = area;
            }
        }
    }
}
