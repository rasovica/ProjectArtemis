using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectPlacer : MonoBehaviour {
    public int gridX = 300;
    public int gridY = 300;
    public float scale = 1.0f;
    public float procentageOfConifers;

    public GameObject ground;
    public GameObject[] conifers;

    private float xOrg;
    private float yOrg;

    void Start() {
        xOrg = Random.Range(0.0f, 1.0f);
        yOrg = Random.Range(0.0f, 1.0f);

        PlaceObjects();
    }

    float Range(float value, float aMin, float aMax, float bMin, float bMax) {
        return bMin + (value - aMin) * (bMax - bMin) / (aMax - aMin);
    }

    void PlaceObjects() {
        float y = 0.0F;
        GameObject conifersObject = GameObject.Find("Conifers");

        while (y < gridY) {
            float x = 0.0F;

            while (x < gridX) {
                float xCoord = xOrg + x / gridX * scale;
                float yCoord = yOrg + y / gridY * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                if (sample < Random.Range(-100.0f, 1.0f)) {
                    int index = (int)Range(sample, 0, 1, 0, conifers.Length);
                    float treeX = Range(x, 0, gridX, -gridX / 2, gridX / 2);
                    float treeY = Range(y, 0, gridY, -gridY / 2, gridY / 2);

                    GameObject tree = Instantiate(conifers[index], new Vector3(treeX, 0, treeY), Quaternion.identity);
                    tree.transform.parent = conifersObject.transform;
                }

                x++;
            }

            y++;
        }
    }
}
