using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BoardBilder
{
    public GameObject floorBox, crate, wall, targetFloorBox, player;
    public GameManager gameManager;

    public void Run(string board)
    {
        var rows = board.Split(
            System.Environment.NewLine.ToCharArray(), 
            System.StringSplitOptions.RemoveEmptyEntries
        );
        System.Array.Reverse(rows);
        
        for (int height = 0; height < rows.Length; ++height)
        {
            var row = rows[height].ToCharArray();

            for (int width = 0; width < row.Length; ++width)
            {
                CreateElement(row[width], width, height);
            }
        }
    }

    private void CreateElement(char elementSign, int width, int height)
    {
        switch (elementSign)
        {
            case '.': // floor
                CreateFloorBox(width, height);
                break;
            case '#': // wall
                CreateWall(width, height);
                break;
            case '@': // crate
                CreateFloorBox(width, height);
                CreateCrate(width, height);
                break;
            case '$': // player
                CreateFloorBox(width, height);
                CreatePlayer(width, height);
                break;
            default:
                Debug.LogError("Unrecognized sign while reading the board");
                break;
        }
    }

    private GameObject CreateFloorElement(int width, int height, GameObject prefab)
    {
        
        var boxInstance = Object.Instantiate(
            prefab,
            new Vector3(width, -0.5f * floorBox.transform.localScale.y, height),
            Quaternion.identity
        );

        var boxInstanceRenderer = boxInstance.GetComponent<Renderer>();
        var material = boxInstanceRenderer.material;

        float hue, saturation, value;
        Color.RGBToHSV(material.color, out hue, out saturation, out value);

        material.color = Random.ColorHSV(
            hue, hue, saturation, saturation, 0.85f, 1f);

        return boxInstance;
    }

    private GameObject CreateFloorBox(int width, int height)
    {
        return CreateFloorElement(width, height, floorBox);
    }

    private GameObject CreateWall(int width, int height)
    {
        var wallInstance = Object.Instantiate(
            wall,
            new Vector3(width, .5f, height),
            Quaternion.identity
        );


        wallInstance.transform.localScale =
            wallInstance.transform.localScale +
            new Vector3(0, Random.Range(0.1f, 0.5f), 0);

        return wallInstance;
    }

    private GameObject CreateCrate(int width, int height)
    {
        return Object.Instantiate(
            crate,
            new Vector3(width, .5f, height),
            Quaternion.identity
        );
    }

    private GameObject CreatePlayer(int width, int height)
    {
        return Object.Instantiate(
            player,
            new Vector3(width, player.transform.position.y, height),
            Quaternion.identity
        );
    }
}
