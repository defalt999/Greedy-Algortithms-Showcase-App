using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraPath
{
    class Kruskal
    {
        public static List<(int from,int to,int cost)> kruskal(int[,] graf)
        {
            //Pas 1 fa lista de muchii
            List<(int from, int to, int cost)> muchii = new();
            //pas 2
            //Se trece prin toata matricea de adiancenta si se adauga valorile in muchii;
            for(int i=0; i< graf.GetLength(0); i++)
            {
                for(int j=0;j<graf.GetLength(1); j++)
                {
                    if (graf[i, j] > 0)
                    {
                        muchii.Add(   (i, j, graf[i,j])   );
                    }
                }

            }
            muchii.Sort((a,b)=> a.cost.CompareTo(b.cost));
            // pas3 Se sorteaza dupa cost

            //Pas 4 Se creeaza un array de parinti
            int[] parinti = new int[graf.GetLength(0)];
            for (int i = 0; i < parinti.Length; i++)
            {
                parinti[i] = i;
                // Se seteaza parintele fiecarui nod la el insusi
            }

            //Functie de find parinte de ex parinti 0 1 0 3 4  daca Find(2) 
            int Find(int x)
            {
                if (parinti[x] != x)
                {
                    parinti[x] = Find(parinti[x]);
                }
                return parinti[x];
            }
            void Union(int x,int y)
            {
                parinti[Find(x)] = Find(y);
            }
            //Functie de uniune a seturilor


            List<(int from, int to, int cost)> mstTree = new();
            foreach(var muchie in muchii)//Pt fiecare muchie 
            {
                if(Find(muchie.from) != Find(muchie.to))//Daca parintele muchiei x e dif de cel a lui y
                {
                    mstTree.Add(muchie);//Adauga in arbore
                    Union(muchie.from,muchie.to);//Uniune
                }
            }

            return mstTree;

        }



    }
}
