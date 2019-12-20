# ProceduralCity

### **Student Name |** Jack Whelan
### **Student Number |** C16499636
### **Program Code |** DT211C/4
### **Project Title |** *Procedural Cityscape Generation in Unity3D*

[![Preview of the Generations](https://github.com/jackwhelan/ProceduralCity/blob/master/Procedural_City_Preview.PNG)](https://www.youtube.com/watch?v=RDSu8uW4eJE)

---

## Summary

This project reached it's goal outlined in the [proposal](PROPOSAL.md) to create a Cityscape procedural generator in Unity3D. I included areas of high rise and some areas of low rise buildings using the Unity perlin noise function. This was mostly to create a sort of urban-flow rather than a completely random cluster of buildings. I also included streets with a random chance of spawning a bench on the path. Another feature I included was park/grassy areas. These grassy areas spawn trees and the trees can be configured to have slight positional variance in order to create a more organic look. Buildings that are generated also have an option for positional variance. All of the buildings, roads, trees and features such as the benches were modelled and textured by myself. I used blender for everything except the trees, for which I used Unity's built-in tree modeller.

## How Does It Work?

The CityScape generator runs on the "BuildCity.cs" script. This script begins by creating a 2D array of integers called "map" of a configured size on which the city will be mapped. A seed can be chosen or a Random Seed option can be enabled, this is used to offset the Perlin Noise. The map array is looped through and filled with returns from the Perlin Noise function with the seed. In order to create more variance amongst the noise generation, the values used to generate it are divided; if this was not done the generation would mostly return the same value. Next a loop runs for the amount of X axis roads configured, through each tile of the map array, replacing the x axis of the given tile with a -1 (signifying an x axis road). Then a loop runs for the amount of Z axis roads configured, through each tile of the map array, replaxing the z axis of the given tile with a -2 (signifying a z axis road). Where a z axis road meets an x axis road, a -3 is placed, signifying a crossroad. Next the map array is looped through in it's entirety, instantiating the objects into the correct tiles depending on their correlated value in the array. Throughout this process, there are checks in place to see if certain features are available: Park Benches; Trees; Building Positional Variance; Tree Positional Variance etc. and they are instantiated if they are enabled and other operations are applied to them upon instantiation. There are random ranges in place to create tree type variance, tree and building positional variance, if they are enabled.

## My Work

It was important to me to do this myself as I am very interested in Game Design and procedural generation. For this reason the vast majority of what I have done I have done from scratch. Every single model used, the buildings, grass areas, roads etc. were all modelled in blender. I didn't know how to use blender before this assignment, I am now very familiar with it and am comfortable using the keybinds and shortcuts. As for the code, I planned to use a map grid from the start but I got the idea to use negative integers overwriting the noise map in order to inject roads into the generation from a tutorial on youtube by Holistic3D. I am very proud of how the mapping system worked out and how seamlessly the roads are generated. I really enjoyed coming up with a solution for the generation of benches on the sides of roads; ensuring they always faced the street using Quaternion rotations. I also really liked the mini feature of positional variance, this gives the generations a more natural look despite being generated on a grid. I also am very proud of how I managed Tree generation and park areas, limiting it to park areas, and making the distribution natural. The Park areas are seamless and look natural.

---

## Proposed Approach - Progression

- [x] Research Procedural Generation Using Perlin Noise.
- [x] Implement an initial generation of basic shapes using Perlin Noise.
- [x] Diversify the generation into clusters of different shapes by manipulating the Perlin Noise.
- [x] Add a character to explore the generations.
- [x] Add park/grassy areas to the generations.
- [x] Add roads/streets to the generations which will punctuate the buildings and parks.
- [x] Create models for buildings, roads, etc. to replace placeholder objects.
- [x] Attempt to add details to the sidewalks, e.g. benches.
- [x] Increase the complexity of generations through the introduction of my own personal algorithms/functions.
- [ ] Add to the detail of city by adding characters/vehicles that traverse the city/streets.

---

## Research / References

I'm usually not a huge fan of sifting through documentation but the Unity documentation has already proved invaluable and has been very easy to navigate and find what I need.

- Unity Documentation
  - [Perlin Noise](https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html)
  - [Pathfinding](https://docs.unity3d.com/Manual/Navigation.html)
  - [Physics](https://docs.unity3d.com/Manual/Physics3DReference.html)
- Youtube Videos
  - [Great playlist on procedural generation by Holistic3d](https://www.youtube.com/watch?v=z1r7VjgufJ8&list=PLi-ukGVOag_0vJMJKAjUyuPF3kMXKW2lV)
  - [Great playlist on procedural building generation by Board to Bits](https://www.youtube.com/watch?v=tP8mB26nKQU&list=PL5KbKbJ6Gf9-FZIwc1M7dbpJIslv-GWFY&index=9)
  - [Great playlist on Blender for beginners](https://www.youtube.com/watch?v=d5luANNKuEc&list=PLs2aOcA-EaLNX5j2yxVQhEBpFgD3zDR9P)
- Other References
  - [Last years procedural city generation](https://youtu.be/Vumj1N2WlFw?list=PL1n0B6z4e_E5qaYwUOlJ63XI2OR9ty7Bs)
  - [Blender tutorials](https://www.blenderguru.com/tutorials)

---

## Tools

- Unity
- Blender (Models)
- Photoshop (Textures)

---
