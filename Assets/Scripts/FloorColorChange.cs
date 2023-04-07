using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloorColorChange : MonoBehaviour
{

    //public GameObject tile;
    public Renderer tile;

    public Material first;
    public Material Red;
    public Material Yellow;
    public Material Blue;
    public Material Green;
    public Material White;
    public TextMeshPro textmesh;
    public bool colorChange;
    private string code;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeColor());
    }

    public void setCode(string c) {
        code = c;
    }

    IEnumerator changeColor()
    {
        while (colorChange)
        {
            tile.material = first;
            yield return new WaitForSeconds(1);
            tile.material = Red;
            yield return new WaitForSeconds(1);
            tile.material = Yellow;
            yield return new WaitForSeconds(1);
            tile.material = Blue;
            yield return new WaitForSeconds(1);
            tile.material = Green;
            yield return new WaitForSeconds(1);
        }
        tile.material = White;
        textmesh.SetText(code);

    }


}
