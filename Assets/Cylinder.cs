using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public RenderTexture texture;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.mainTexture = texture;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
