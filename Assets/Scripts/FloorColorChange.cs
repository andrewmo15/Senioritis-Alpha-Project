using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColorChange : MonoBehaviour
{

    //public GameObject tile;
    public Renderer tile;

    public Material Red;
    public Material Yellow;
    public Material Blue;
    public Material Green;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeColor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator changeColor()
    {
        while (true)
        {
            tile.material = Red;
            yield return new WaitForSeconds(1);
            tile.material = Yellow;
            yield return new WaitForSeconds(1);
            tile.material = Blue;
            yield return new WaitForSeconds(1);
            tile.material = Green;
            yield return new WaitForSeconds(1);
        }
        
    }


}
