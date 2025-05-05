using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraPath
{
    class Prim
    {

        public static List<(int from,int to,int cost)> prim( int[,] graf,int start)
        {
            int n = graf.GetLength(0);
            bool[] visited = new bool[n];
            var mst = new List<(int from, int to, int cost)>();
            //Pas 1 avem toate nodurile deconectate

            visited[start] = true;
            //Ruleaza pana se umple mst
            while(mst.Count < n - 1)
            {   //Setam mincost default si from si to
                int minCost = int.MaxValue;
                int from = -1; int to = -1;

                //Ruleaza pt toate nodurile
                for(int i = 0; i < n ; i++)
                {
                    if (visited[i])//daca a fost vizitat (La inceput doar starturl o sa fie vizitat si incepe de la el)
                    {
                        //Trecem prin toate nodurile
                        for (int j = 0; j < n; j++) 
                        {

                            //Daca nu a fost vizitat si e legat la i adica sursa
                            if (!visited[j] && graf[i, j] > 0)
                            {
                                //Daca costul e mai mic ca minCost
                                if (graf[i, j] < minCost)
                                {
                                    minCost = graf[i, j];
                                    from = i;//Setare mincost from si to
                                    to = j;
                                }
                            }
                        }
                    }
                }
                //Daca am gasit un nod de cost minim
                if (minCost != int.MaxValue)
                {
                    visited[to] = true;
                    mst.Add((from, to, minCost));
                }
                else
                {
                    break;
                }


            }
            return mst;

        }
    }
}
