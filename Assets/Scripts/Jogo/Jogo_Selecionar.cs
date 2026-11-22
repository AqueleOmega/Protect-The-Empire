using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Internal;

public class Jogo_Selecionar : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material material1, material2;
    Material[] materiais = new Material[2];
    List<GameObject> objetos_destacados = new List<GameObject>();

    public LayerMask layerTropa;
    public LayerMask layerGround;

    public Camera camera1;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Selecionar()
    {
        Vector3 posGround = new Vector3();

        Material[] materiais = new Material[2];

        materiais[0] = material1;
        materiais[1] = material2;


        Vector3 positionMouse = Input.mousePosition;
        Ray myRay = camera1.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        Debug.Log("1");

        if (Physics.Raycast(myRay, out raycastHit, Mathf.Infinity, layerTropa)) //se atingir uma tropa
        {
            MeshRenderer alvoRenderer = raycastHit.transform.GetComponent<MeshRenderer>();
            materiais[1] = material2;
            alvoRenderer.sharedMaterials = materiais; //coloca o outline
            objetos_destacados.Add(raycastHit.transform.gameObject); 

        }
        else
        {
            if (Physics.Raycast(myRay, out raycastHit, Mathf.Infinity, layerGround)) //se atingir um chão
            {
                posGround = raycastHit.point;
                materiais[1] = material1;

                foreach (GameObject objeto in objetos_destacados)
                {
                    MeshRenderer alvoRenderer = objeto.GetComponent<MeshRenderer>();
                    Movimento scriptMovimento = objeto.GetComponent<Movimento>();
                    scriptMovimento.Movimentar(posGround);
                    alvoRenderer.sharedMaterials = materiais;
                }
            }
        }
    }
}
