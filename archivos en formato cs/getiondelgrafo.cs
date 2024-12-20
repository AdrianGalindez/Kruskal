using System;
using System.Collections.Generic;
using UnityEngine;

public class GraphKruskal : MonoBehaviour
{
    public class Arista : IComparable<Arista>
    {
        public int desde, haciadonde;
        public float peso;

        public Arista(int desde, int hacia, float peso)
        {
            this.desde = desde;
            this.haciadonde = hacia;
            this.peso = peso;
        }

        public int CompareTo(Arista otra)
        {
            return peso.CompareTo(otra.peso);
        }
    }

    public class Conjuntodisjunto
    {
        private int[] padre, rango;

        public Conjuntodisjunto(int tamaño)
        {
            padre = new int[tamaño];
            rango = new int[tamaño];
            for (int i = 0; i < tamaño; i++) padre[i] = i;
        }

        public int Find(int nodo)
        {
            if (padre[nodo] != nodo)
                padre[nodo] = Find(padre[nodo]);
            return padre[nodo];
        }

        public void Union(int nodo1, int nodo2)
        {
            int raíz1 = Find(nodo1);
            int raíz2 = Find(nodo2);

            if (raíz1 != raíz2)
            {
                if (rango[raíz1] > rango[raíz2])
                    padre[raíz2] = raíz1;
                else if (rango[raíz1] < rango[raíz2])
                    padre[raíz1] = raíz2;
                else
                {
                    padre[raíz2] = raíz1;
                    rango[raíz1]++;
                }
            }
        }
    }

    public List<Arista> Kruskal(int numNodos, List<Arista> arista)
    {
        arista.Sort();
        Conjuntodisjunto ds = new Conjuntodisjunto(numNodos);

        List<Arista> result = new List<Arista>();
        foreach (var edge in arista)
        {
            if (ds.Find(edge.desde) != ds.Find(edge.haciadonde))
            {
                result.Add(edge);
                ds.Union(edge.desde, edge.haciadonde);
            }
        }

        return result;
    }
 
}

































