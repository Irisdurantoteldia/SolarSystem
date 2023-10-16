using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;

    public GameObject panelA;
    public GameObject panelB;
    // Start is called before the first frame update
    void Start()
    {
        DisableAllCameras();
        cameras[0].SetActive(true);

        panelA.SetActive(true);
        panelB.SetActive(false);
    }

    void DisableAllCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisableAllCameras();
            cameras[0].SetActive(true);
        }
        
         if (Input.GetKeyDown(KeyCode.W))
        {
            DisableAllCameras();
            cameras[1].SetActive(true);
        }

         if (Input.GetKeyDown(KeyCode.E))
        {
            DisableAllCameras();
            cameras[2].SetActive(true);
        }

         if (Input.GetKeyDown(KeyCode.R))
        {
            DisableAllCameras();
            cameras[3].SetActive(true);
        }

         if (Input.GetKeyDown(KeyCode.T))
        {
            DisableAllCameras();
            cameras[4].SetActive(true);
        }

         if (Input.GetKeyDown(KeyCode.Space))
        {
            panelA.SetActive(!panelA.activeSelf);
            panelB.SetActive(!panelB.activeSelf);
        }
        
    }
}
