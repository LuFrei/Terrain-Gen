using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuFrei.LevelGeneration;

//A way to output console log for testing purposes
public class TestLogger : MonoBehaviour
{
    private TerrainGenerator TerraGen = new TerrainGenerator(); 

    void Start() {
        int[] seed = TerrainGenerator.generateSeed();
        Debug.Log(seed);
    }
}
