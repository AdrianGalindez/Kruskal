using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public Transform[] points; // Arreglo de puntos para el recorrido del láser

    private LineRenderer lineRenderer;

    void Start()
    {
        // Obtener el componente LineRenderer
        lineRenderer = GetComponent<LineRenderer>();

        // Configurar el ancho del láser
        lineRenderer.startWidth = 10f;
        lineRenderer.endWidth = 10f;

        // Configurar la cantidad de puntos en el LineRenderer
        lineRenderer.positionCount = points.Length;

        // Establecer las posiciones de los puntos en el LineRenderer
        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
 
}
