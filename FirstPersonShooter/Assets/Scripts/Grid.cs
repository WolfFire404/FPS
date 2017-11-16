﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject plane;
    public int width = 20;
    public int height = 20;
	public float timer = 1;

    private Color[,] grid;

    void Awake()
    {
        grid = new Color[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var gridPlane = Instantiate(plane);//.GetComponent<Color>();
                gridPlane.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                gridPlane.transform.position = new Vector3(transform.position.x + x,
                    transform.position.y + y, transform.position.z);
                grid[x, y] = gridPlane.GetComponent<Color>();
            }
        }
    }




    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hit;
			Physics.Raycast(ray, out hit, 1000)
            Color c = hit.collider.GetComponent<Color>();
            c.SwitchColor();
        }

     //   if (Input.GetKeyDown(KeyCode.Space))
      //      Step();

		if (GlobalVariables.thisShitOn && timer <=0) {
			timer = 1;
			Step ();
		
		}

		timer -= Time.deltaTime;
    }


    void Step()
    {
        List<int[]> states = new List<int[]>();

        for (int x = 0; x < grid.GetLength(0); x++)
        {   
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                int neighbors = GetNeighbors(x, y);
                Color currentCell = grid[x, y];
                if (currentCell.Alive && (neighbors < 2 || neighbors > 3)) states.Add(new int[] { x, y, 0 });
                else if (!currentCell.Alive && neighbors == 3) states.Add(new int[] { x, y, 1 });
            }
        }

        foreach(var state in states)
        {
            grid[state[0], state[1]].Alive = state[2] == 1 ? true : false;
        }
    }

    int GetNeighbors(int x, int y)
    {
        int[,] positions = new int[,]
        {
            {-1,-1 },{0,-1 },{1,-1 },
            {-1,0 },         {1,0 },
            {-1,1 }, {0,1 }, {1,1 }
        };

        int horse = 0;
        for (int i = 0; i < positions.GetLength(0); i++)
        {
            int nx = x + positions[i, 0];
            if (nx < 0) nx = width - 1;
            if (nx >= width) nx = 0;

            int ny = y + positions[i, 1];
            if (ny < 0) ny = height - 1;
            if (ny >= height) ny = 0;


            Color color = grid[nx, ny];
            if (color.Alive) ++horse;
        }

        return horse;
    }
}
