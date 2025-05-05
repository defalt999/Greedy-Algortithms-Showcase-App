using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraPath
{
    class Dijkstra
    {
        public static int[] dijkstra(int[,] graf,int start)
        {
            int n = graf.GetLength(0);
            int[] dist = new int[n];
            bool[] visited = new bool[n];
            //Declaram sir cu distatnte si cu visitate

            for(int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }
            //Umplem arrayurile cu valori infinite si false
            dist[start] = 0;
            //distanat de la start la start este 0
            for(int i=0; i < n-1; i++)//Se executia de n-1 ori
            {
                int minDist = int.MaxValue , u=-1;//U este nodul cel mai apropiat
                for(int k=0; k < n; k++)
                {//Verificam daca nodul K e visitat si daca distanta lui 
                 // E mai mica decat minDist (initial infinit)
                 //Daca daca se act mindist si nodul
                    if (!visited[k] && dist[k] < minDist)
                    {
                        minDist = dist[k];
                        u = k;
                    }

                }
                if (u == -1)
                    break;
                visited[u] = true;

                for(int v = 0; v < n; v++)
                {
                    if (graf[u,v]>0 && !visited[v])
                    {
                        int newDist = dist[u] + graf[u, v];
                        if (newDist < dist[v])
                        {
                            dist[v] = newDist;
                      
                        }
                    }
                }
            }
            return dist;
        }
    }
}
