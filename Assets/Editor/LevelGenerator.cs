using UnityEngine;
using UnityEditor;

public class LevelGenerator : EditorWindow
{
    private int gridSizeX = 10;
    private int gridSizeZ = 10;
    private GameObject tilePrefab;
    private GameObject[,] gridTiles;

    private int sectionSpacing = 10;
    private Transform gridParent;

    [MenuItem("Tools/Level Generator")]
    public static void ShowWindow()
    {
        GetWindow<LevelGenerator>("Level Generator");
    }
    private void OnGUI()
    {
        GUILayout.Label("Grid Dimension X", EditorStyles.boldLabel);
        gridSizeX = EditorGUILayout.IntField("Grid Dimension X", gridSizeX);
        GUILayout.Space(sectionSpacing);
        GUILayout.Label("Grid Dimension Z", EditorStyles.boldLabel);
        gridSizeZ = EditorGUILayout.IntField("Grid Dimension Z", gridSizeZ);
        GUILayout.Space(sectionSpacing);
        GUILayout.Label("Tile Prefab", EditorStyles.boldLabel);
        tilePrefab = (GameObject)EditorGUILayout.ObjectField("Tile Prefab", tilePrefab, typeof(GameObject), false);
        GUILayout.Space(sectionSpacing);
        GUILayout.Label("Grid Parent", EditorStyles.boldLabel);
        gridParent = (Transform)EditorGUILayout.ObjectField("Grid Parent", gridParent, typeof(Transform), true);
        GUILayout.Space(sectionSpacing);

        if (GUILayout.Button("Generate Grid"))
        {
            GenerateGrid();
        }
        if (GUILayout.Button("Clear Grid"))
        {
            ClearGrid();
        }
    }
    private void ClearGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                DestroyImmediate(gridTiles[x, z]);
            }
        }
    }
    private void GenerateGrid()
    {
        
        if (tilePrefab == null)
        {
            Debug.LogError("Tile prefab is not assigned!");
            return;
        }
        gridTiles = new GameObject[gridSizeX, gridSizeX];
        for (int x =0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                gridTiles[x,z] = (GameObject) PrefabUtility.InstantiatePrefab(tilePrefab, gridParent);
                gridTiles[x, z].transform.position = position;
            }
        }
    }
}
