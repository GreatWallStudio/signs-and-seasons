using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChangeMaterial : MonoBehaviour
{
    //give a place in the inspector to specify the material to use
    [SerializeField] private Material new_material;

    //make a variable for the renderer, because that is where the material is set
    MeshRenderer thisRenderer;

    void Start()
    {
        //get the renderer component
        //thisRenderer = GetComponent<MeshRenderer>();

        //change the material for this object
        //thisRenderer.material = new_material;

        //get the mesh component
        //Mesh mesh = GetComponent<MeshFilter>().mesh;

        //flip all normals so the material shows on the inside
        //mesh.triangles = mesh.triangles.Reverse().ToArray();

    }

   void Update()
    {
        float rotationValue = Time.time * 4f;
        Quaternion quaternionRotationValue = Quaternion.Euler(0f, 32.5f, rotationValue);
        this.gameObject.transform.rotation = quaternionRotationValue;
    }

    // Astronomy Experiment
    public void rotateSkybox()
    {
        float rotationValue = Time.time * 4f;
        Quaternion quaternionRotationValue = Quaternion.Euler(0f, 0f, rotationValue);
        this.gameObject.transform.rotation = quaternionRotationValue;
    }
}
