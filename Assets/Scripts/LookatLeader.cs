using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatLeader : MonoBehaviour
{
    GameObject leader = null;
    private string CamDir = "down";

    void Start() {
        InvokeRepeating("FindLeader", 0, 1);
        InvokeRepeating("SwitchCamDir", 15, 15);
    }

    private void Update() {
        if (CamDir == "down") {
            transform.RotateAround(GameObject.Find("Sphere").transform.position, Vector3.down, 10 * Time.deltaTime);
        } else {
            transform.RotateAround(GameObject.Find("Sphere").transform.position, Vector3.up, 10 * Time.deltaTime);
        }
        transform.LookAt(GameObject.Find("Sphere").transform);
        if (leader != null) {
            GameObject.Find("Sphere").transform.position = new Vector3(GameObject.Find("Sphere").transform.position.x, GameObject.Find("Sphere").transform.position.y, leader.transform.position.z);
        }
    }

    public void FindLeader() {
        GameObject[] racerObjects = GameObject.FindGameObjectsWithTag("Player");
        if (racerObjects.Length != 0) {
            float[] poss = new float[racerObjects.Length];
            for (int r = 0; r < racerObjects.Length; r++) {
                poss[r] = racerObjects[r].transform.position.z;
            }
            float maxValue = poss.Max();
            int maxIndex = poss.ToList().IndexOf(maxValue);
            GameObject newLeader = racerObjects[maxIndex];
            if (newLeader != leader) {
                leader = newLeader;
                transform.SetParent(leader.transform);
            }
        }
    }

    private void SwitchCamDir () {
        if (CamDir == "down") {
            CamDir = "up";
        } else {
            CamDir = "down";
        }
    }
}
