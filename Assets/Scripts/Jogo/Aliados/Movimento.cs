using System;
using UnityEngine;

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
    void Update()
    {
        
    }

    public void Movimentar(Vector3 position)
    {
        Vector3 vector_dist = position - transform.position;
        Vector2 dist_norm = new Vector2(vector_dist.x, vector_dist.z).normalized;
        Debug.Log($"Valor da posição OG: {position} agr {transform.position} diff {vector_dist} norm {dist_norm}");
        rb.linearVelocity = new Vector3(vector_dist.x, 0, dist_norm.y) * velocidade;
    }
}
