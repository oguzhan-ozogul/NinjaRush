using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knives : MonoBehaviour
{
    public Transform modelRoots;


    private void Update()
    {

        modelRoots.Rotate(360 * Time.deltaTime, 0, 0);
    }
    
    

}

    
    