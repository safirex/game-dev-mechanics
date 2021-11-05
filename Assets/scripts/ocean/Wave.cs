using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    //https://www.youtube.com/watch?v=_Ij24zRI9J0
    public int dimension = 10;
    public float UVScale;
    //Mesh
    protected MeshFilter meshFilter;
    protected Mesh mesh;

    public Octave[] octaves;

    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public Boolean alternate;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Mesh Setup
        mesh = new Mesh();
        mesh.name = gameObject.name;

        mesh.vertices = GenerateVerts();
        mesh.triangles = GenerateTries();
       // mesh.uv = GenerateUVs();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }


    // Update is called once per frame
    void Update()
    {
        var verts = mesh.vertices;
        for (int x = 0; x < dimension; x++)
        {
            for (int z = 0; z < dimension; z++)
            {
                var y = 0f;
                Octave oct;
                for (int octIndex = 0; octIndex < octaves.Length; octIndex++)
                {
                    oct = octaves[octIndex];
                    if (oct.alternate)
                    {
                        var perl = Mathf.PerlinNoise((x * oct.scale.x + Time.time * oct.speed.x) / dimension, (z * oct.scale.y + Time.time * oct.speed.y) / dimension) - 0.5f;

                        y += perl * oct.height;
                    }
                }

                verts[index(x, z)] = new Vector3(x, y, z);
            }
        }
        mesh.vertices = verts;
    }



    private Vector2[] GenerateUVs()
    {
        var uvs = new Vector2[mesh.vertices.Length];

        //always set one uv over n tiles than flip the uv and set it again
        for (int x = 0; x <= dimension; x++)
        {
            for (int z = 0; z <= dimension; z++)
            {
                var vec = new Vector2((x / UVScale) % 2, (z / UVScale) % 2);
                uvs[index(x, z)] = new Vector2(vec.x <= 1 ? vec.x : 2 - vec.x, vec.y <= 1 ? vec.y : 2 - vec.y);
            }
        }

        return uvs;
    }

    private int[] GenerateTries()
    {
        // 3 vertex per triangle, 2 triangle per tile
        var tries = new int[mesh.vertices.Length * 6];

        //effet de bordure
        for (int x = 0; x < dimension-1; x++)
        {
            for(int z = 0; z < dimension-1; z++)
            {
                tries[index(x, z) * 6 + 0] = index(x, z);
                tries[index(x, z) * 6 + 1] = index(x + 1, z + 1);
                tries[index(x, z) * 6 + 2] = index(x + 1, z);
                tries[index(x, z) * 6 + 3] = index(x, z);
                tries[index(x, z) * 6 + 4] = index(x, z + 1);
                tries[index(x, z) * 6 + 5] = index(x + 1, z + 1);
            }
        }
        return tries;
    }

    private Vector3[] GenerateVerts()
    {
        var verts = new Vector3[(dimension) * dimension];
        for (int x = 0; x < dimension; x++)
        {
            for(int z=0; z < dimension; z++)
            {
                verts[index(x, z)] = new Vector3(x, 0, z);
            }
        }


        return verts;
    }

    private int index(int x, int z)
    {
        return x * dimension + z;
    }



}