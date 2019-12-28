using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject floorBox, crate, wall, player;
    public TextAsset board;

    private void Awake()
    {
        new BoardBilder
        {
            floorBox = floorBox,
            crate = crate,
            wall = wall,
            player = player,
            gameManager = this
        }.Run(board.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
