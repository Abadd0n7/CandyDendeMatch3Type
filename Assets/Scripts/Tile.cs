using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private GameObject selectObject; // game obj

    void Start()
    {

    }
    void Update()
    {
        //selectObject = GetComponent<GameObject>();
        Move();
    }

    private void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Działa.");
            GameObject gameObject = hit.transform.root.gameObject;

            Select(gameObject);
        }
        else
        {
            Deselect();
        }

    }

    void Select(GameObject obj)
    {
        if (selectObject != null)
        {
            if (obj == selectObject)
            {
                return;
            }

            Deselect();
        }

        selectObject = obj;

        Renderer[] rend = selectObject.GetComponentsInChildren<Renderer>();
        foreach(var r in rend)
        {
            Material m = r.material;
            m.color = Color.red;
            r.material = m;
        }
    }

    void Deselect()
    {
        if (selectObject == null)
            return;

        Renderer[] rend = selectObject.GetComponentsInChildren<Renderer>();
        foreach (var r in rend)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }
    }
}