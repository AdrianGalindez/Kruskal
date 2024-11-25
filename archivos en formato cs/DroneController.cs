using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public Transform[] puntosRuta;  // Puntos por donde pasará el dron
    public float velocidad = 5f;       // Velocidad del dron
    private int puntoactual = 0;

    private List<GraphKruskal.Arista> camino;  // Ruta obtenida con Kruskal

    private void Start()
    {
        // Simulación: Configurar aristas entre los puntos para probar Kruskal
        List<GraphKruskal.Arista> arista = new List<GraphKruskal.Arista>
        {
            new GraphKruskal.Arista(0, 1, Vector3.Distance(puntosRuta[0].position, puntosRuta[1].position)),
            new GraphKruskal.Arista(1, 2, Vector3.Distance(puntosRuta[1].position, puntosRuta[2].position)),
            new GraphKruskal.Arista(0, 2, Vector3.Distance(puntosRuta[0].position, puntosRuta[2].position))
        };

        GraphKruskal grafo = new GraphKruskal();
        camino = grafo.Kruskal(puntosRuta.Length, arista);

        // Iniciar el movimiento del dron
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        while (true)
        {
            Transform target = puntosRuta[puntoactual];
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
                yield return null;
            }

            puntoactual = (puntoactual + 1) % puntosRuta.Length;
            yield return new WaitForSeconds(1f);  // Espera antes de moverse al siguiente punto
        }
    }
   
}






















/*
   public Transform[] puntosRuta;  // Puntos por donde pasará el dron
   public float velocidad = 5f;       // Velocidad del dron
   private int currentWaypoint = 0;

   private List<GraphKruskal.Edge> pathEdges;  // Ruta obtenida con Kruskal

   private void Start()
   {
       // Simulación: Configurar aristas entre los puntos para probar Kruskal
       List<GraphKruskal.Edge> edges = new List<GraphKruskal.Edge>
       {
           new GraphKruskal.Edge(0, 1, Vector3.Distance(puntosRuta[0].position, puntosRuta[1].position)),
           new GraphKruskal.Edge(1, 2, Vector3.Distance(puntosRuta[1].position, puntosRuta[2].position)),
           new GraphKruskal.Edge(0, 2, Vector3.Distance(puntosRuta[0].position, puntosRuta[2].position))
       };

       GraphKruskal graph = new GraphKruskal();
       pathEdges = graph.Kruskal(puntosRuta.Length, edges);

       // Iniciar el movimiento del dron
       StartCoroutine(FollowPath());
   }

   private IEnumerator FollowPath()
   {
       while (true)
       {
           Transform target = puntosRuta[currentWaypoint];
           while (Vector3.Distance(transform.position, target.position) > 0.1f)
           {
               transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
               yield return null;
           }

           currentWaypoint = (currentWaypoint + 1) % puntosRuta.Length;
           yield return new WaitForSeconds(1f);  // Espera antes de moverse al siguiente punto
       }
   }
   */