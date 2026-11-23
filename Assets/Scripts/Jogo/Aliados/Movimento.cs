using System;
using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour, IAliado
{
    [SerializeField] private float velocidade = 1;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = transform.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void Movimentar(Vector3 position)
    {
        Vector3 vector_dist = position - transform.position;
        Vector2 dist_norm = new Vector2(vector_dist.x, vector_dist.z).normalized;
        //Debug.Log($"Valor da posi��o OG: {position} agr {transform.position} diff {vector_dist} norm {dist_norm}");
        rb.linearVelocity = new Vector3(dist_norm.x, 0, dist_norm.y) * velocidade;
        float distanciaponto = vector_dist.x + vector_dist.y + vector_dist.z;
        StartCoroutine(Verification(position));
    }

    
    IEnumerator Verification(Vector3 position)
    {
        int a = 1;
        while (a != 2)
        {
            yield return new WaitForFixedUpdate();
            Vector3 vector_dist = position - transform.position;
            float distanciaponto = vector_dist.x + vector_dist.z;   

            if (distanciaponto < 0.1f && distanciaponto > -0.1f)
            {
                rb.linearVelocity = new Vector3(0, 0, 0);
                a = 2;
            }
        }
        Debug.Log("Parou");
    }

    
}
