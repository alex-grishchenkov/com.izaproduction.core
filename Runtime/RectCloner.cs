using UnityEngine;
using System.Collections;

public class RectCloner : MonoBehaviour
{
    // Instantiates prefabs in a rectangle formation
    [SerializeField]
    public GameObject [] prefabs;
    [SerializeField]
    public int columns = 5;
    public int rows = 5;
    public int colSpace = 5;
    public int rowSpace = 5;
    public float rotationY = 0;
    public int seed = 42;
    int index;

    void Start()
    {
        Random.InitState(seed);

        for (int i = 0; i < rows; i++)
        {
            index = Random.Range(0, prefabs.Length);
            Quaternion rot = Quaternion.Euler(0, rotationY, 0); 
            float x = i * rowSpace;
            float z = 0;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            Instantiate(prefabs[index], pos, rot);

            for (int ii= 1; ii < columns; ii++)
            {
                index = Random.Range(0, prefabs.Length);
                float zz = ii * colSpace;
                Vector3 pos2 = transform.position + new Vector3(x, 0, zz);
                Instantiate(prefabs[index], pos2, rot);

            }
        }
    }
}