using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.InputSystem;

public class Jogo_Selecionar : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material material1, material2;
    Material[] materiais = new Material[2];
    List<GameObject> objetos_destacados = new List<GameObject>();

    public LayerMask layerTropa;
    public LayerMask layerGround;

    public Camera camera1;

    public InputAction Shift;

    
    
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
        Debug.Log(objetos_destacados.Count);

        //logica to-do: checa se atingiu o chão
        if (objetos_destacados.Count != 0) //se já tem algum objeto destacado
        {
            Debug.Log("if");
            if (Shift.IsPressed()) //se o shift apertado
            {
                if (Physics.Raycast(myRay, out raycastHit, Mathf.Infinity, layerTropa)) //se atingir uma tropa
                {
                    MeshRenderer alvoRenderer = raycastHit.transform.GetComponent<MeshRenderer>();
                    materiais[1] = material2;
                    alvoRenderer.sharedMaterials = materiais; //coloca o outline
                    objetos_destacados.Add(raycastHit.transform.gameObject);
                }

                else
                {
                    if (Physics.Raycast(myRay, out raycastHit, Mathf.Infinity, layerGround)) //se atingir um ch�o
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

                        objetos_destacados.Clear();
                    }
                }
            }

            else
            {
                if (Physics.Raycast(myRay, out raycastHit, Mathf.Infinity, layerGround))
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

                objetos_destacados.Clear();
                }
            }
        }
        else //se não tem algum objeto destacado
        {
            Debug.Log("else");
            if (Physics.Raycast(myRay, out raycastHit, Mathf.Infinity, layerTropa)) //se atingir uma tropa
            {
                Debug.Log("TRopa");
                MeshRenderer alvoRenderer = raycastHit.transform.GetComponent<MeshRenderer>();
                materiais[1] = material2;
                alvoRenderer.sharedMaterials = materiais; //coloca o outline
                objetos_destacados.Add(raycastHit.transform.gameObject);
            }

            else
            {
                Debug.Log("ground");
                if (Physics.Raycast(myRay, out raycastHit, Mathf.Infinity, layerGround)) //se atingir um ch�o
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

                objetos_destacados.Clear();
                }
            }
        }
    }
}
