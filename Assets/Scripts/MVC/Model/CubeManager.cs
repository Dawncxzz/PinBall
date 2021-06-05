using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager: BaseManager<CubeManager>
{
    private List<Cube> curArray = new List<Cube>();
    public Cube AddCube(string cubeName)
    {
        Cube cube;
        switch (cubeName)
        {
            case "CubeA":
                cube = new CubeA();
                break;
            case "CubeB":
                cube = new CubeB();
                break;
            case "CubeC":
                cube = new CubeC();
                break;
            default:
                cube = null;
                break;
        }
        if (cube != null)
        {
            curArray.Add(cube);
            return cube;
        }
        return null;
    }
    public void DeleteCube(Cube cube)
    {
        curArray.Remove(cube);
    }
}
public abstract class Cube
{
    public Cube() { }
    public int id { get; set; }
    public int health { get; set; }
    public string type { get; set; }
}
public class CubeA : Cube
{
    public CubeA()
    {
        id = 1;
        health = 1;
        type = "A";
    }
}
public class CubeB : Cube
{
    public CubeB()
    {
        id = 2;
        health = 2;
        type = "B";
    }
}
public class CubeC : Cube
{
    public CubeC()
    {
        id = 3;
        health = 3;
        type = "C";
    }
}
