using System;
using System.Collections.Generic;

namespace LuFrei.LevelGeneration {
    public class TerrainGenerator {


        static public int[] generateSeed(int length = 10){
            Random random = new Random();

            int[] seed = new int[length];

            for(int i = 0; i < length; i++){
                seed[i] = random.Next(0, 101);
            }

            return seed;
        }


        //Notes:
        // We need slowly integrate each element of the array into the final array, sort of "layering them"
        // Ex: src: [1, 4, 2, 7, 4, 5, 4, 9, 5]
        //      1st: [1](0.5) //Despite the tutorial having this, do we really need it?
        //      2nd: [1, 4](0.25)
        //      3rd: [1, 2, 4, 4](0.125)
        //      4th: [1, 4, 2, 7, 4, 5, 4, 9 ,5](0.0625)
        // **0.5 curve might be too harsh but it was simple enough for the example
        //
        // Big Q: How do we deal with in-between values?
        //        As of now we have huge holes in our data that wont really add up.
        // Ex above technically lines up as:
        //      1st: [0.5   ,     ,      ,       ,     ,       ,     ,       ,  ]
        //      2nd: [0.25  ,     ,      ,       , 1   ,       ,     ,       ,  ]
        //      3rd: [0.125 ,     , 0.25 ,       , 0.5 ,       , 0.5 ,       , 1.125]
        //      4th: [0.0625, 0.25, 0.125, 0.4375, 0.25, 0.3125, 0.25, 0.5625, 0.3125]
        // - This is the data dispersement we want, but when we turn this 
        //   into points to draw out we get:
        //           [0.9375, 0.25, 0.375, 0.4375, 1.75, 0.3125, 0.75, 0,5625, 1.4375]
        //   In general, we want the few values to effect ALL values under them, 
        //   not jsut the same element in the next iteration.
        //
        // We want a blanketing effect where each layer is representative of slops between each "key point"
        // Ex:  1st: [0.5, 0.5, 0.5, 0.5, 1, 1, 1, 1, 1, 1]
        //      2nd: [1, 1.75, 2.5, 3.25, 4, 3.25, 2.5, 1.75]
        //      3rd: [1, 1.5, 2, 3, 4, 4, 4, 4.5, 5]
        //      4th: [1, 4, 2, 7, 4, 5, 4, 9, 5]
        // We can have a degree of scale: the delta between each layer
        // Ex: Scale degree of 1/2: each layer multiplied by half of last layer
        //                1st pass: x0.5
        //                2nd pass: x0.25
        //                3rd pass: x0.125
        //                4th pass: x0.0625
        //                          etc.
        //
        // Bonus: change the operation: From multiplying steady intervals to exponential curve
        //        Get total elemnts in Array and multiply each layer index over total
        //        i.e.: i/array.length
        //        Or for smoother terrain, reverse it
        //        i.e.: (i-array.length)/array.length
        //          This way, we get a curve where the more details are smaller wile less details are larger.
        //          I want to allow for the former way anyway just to see howresults would turn out.
        // Ex: 

  
        static public int[,] generateHeightMap(int[] seed){
            
            if(seed.Length < 1){
                seed = generateSeed();
            }

            int resolution = seed.Length;

            int [,] heightMap = new int[resolution, resolution];

            return heightMap;
        }
    }
}
