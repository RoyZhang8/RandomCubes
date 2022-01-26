/****
 * Created By: Ruoyu Zhang
 * Data Created: Jan 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 26, 2022
 * 
 * Descripetion: Spawn multiple cubes prefabs into the secen.
 * ***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; //Total number of cubes instatied

    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes



    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instatates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to the number of cubes

        GameObject gOBj = Instantiate<GameObject>(cubePrefab); // creates cube instance

        gOBj.name = "Cube" + numberOfCubes; // name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); // add new color

        gOBj.GetComponent<Renderer>().material.color = randColor; //assigns random color to game object


        gOBj.transform.position = Random.insideUnitSphere; // random location inside sphere radius of 1 out from 0,0,0

        gameObjectList.Add(gOBj); // add to list

        List<GameObject> removeList = new List <GameObject>(); // list for removed

        foreach (GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor; //scale multipled by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }// end if (scale <= 0.1f)
        }// end foreach(GameObject goTemp in gameObjectList)

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from game object list
            Destroy(goTemp); //destorys game object
        }// end foreach(GameObject goTemp in removeList)

        Debug.Log(removeList.Count); //debugs the remove list
    }
}
