using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuFrei.LevelGenerator {
    static public class TerrainGeneration {
        static public int[] generateSeed(int length = 10){
            int[] seed = new int[length];

            for(int i = 0; i < length; i++){
                seed[i] = Random.Range(0, 101);
            }

            return seed;
        }
    }
}
