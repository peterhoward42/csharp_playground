using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Town
    {
        public string name;
        public bool visited;
        public IDictionary<string, int> neighbours; // edge distances

        public Town(string name)
        {
            this.name = name;
            this.visited = false;
            this.neighbours = new Dictionary<string, int>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var towns = new Dictionary<string, Town>();

            addEdge(towns, "chippenham", "lyneham", 4);
            addEdge(towns, "lyneham", "swindon", 5);
            addEdge(towns, "swindon", "cherhill", 3);
            addEdge(towns, "cherhill", "calne", 1);
            addEdge(towns, "calne", "melksham", 6);
            addEdge(towns, "melksham", "chippenham", 5);
            addEdge(towns, "calne", "lyneham", 3);

            string startTown = "chippenham";
            var dynamicDist = new Dictionary<string, int>();
            seedTable(startTown, towns, dynamicDist);
            
            string nextTownToVisit;
            while ((nextTownToVisit = chooseNext(towns, dynamicDist)) != null)
                {
                    Console.WriteLine("Next to visit is: {0}", nextTownToVisit);
                    visit(nextTownToVisit, towns, dynamicDist);
                }
            showConclusion(dynamicDist);
         }

        

        private static void addEdge(IDictionary<string, Town> towns, string t1, string t2, int dist)
        {
            if (towns.ContainsKey(t1) == false)
            {
                towns.Add(t1, new Town(t1));
            }
            if (towns.ContainsKey(t2) == false)
            {
                towns.Add(t2, new Town(t2));
            }
            towns[t1].neighbours[t2] = dist;
            towns[t2].neighbours[t1] = dist;
        }

        private static void seedTable(string startTown, IDictionary<string, Town> towns, IDictionary<string, int> dynamicDist)
        {
            // Initialise dynamic distances table to very large (sentinel) values
            foreach (string town in towns.Keys)
                dynamicDist[town] = HUGE;
            // Put in distances of start node's immediate neighbours into distances known so far table
            foreach (string neighbour in towns[startTown].neighbours.Keys)
            {
                dynamicDist[neighbour] = towns[startTown].neighbours[neighbour];
            }
            // And initialise start town as a special case
            dynamicDist[startTown] = 0;
            towns[startTown].visited = true;
        }

        private static string chooseNext(Dictionary<string, Town> towns, IDictionary<string, int> dynamicDist)
        {
            // We choose the town in the table from the subset that have not yet
            // been visited, for which the known distance back to the start
            // is smallest.
            int shortest = HUGE;
            string toVisit = "";
            foreach (string town in towns.Keys)
            {
                if (towns[town].visited)
                    continue;
                int dist = dynamicDist[town];
                if (dist < shortest)
                {
                    shortest = dist;
                    toVisit = town;
                }
            }
            return (toVisit.Equals("") ? null: toVisit);
        }

        private static void visit(string thisTown, IDictionary<string, Town> towns, IDictionary<string, int> dynamicDist)
        {
            // Consider all of this town's unvisited neighbours and measure the best known distance from the start
            // town to it, by adding the hop distance to the best distance known
            // so far up as far as this town. If the distance calculated improves on
            // the best recorded distance, then update same to the new value.
            towns[thisTown].visited = true;
            foreach (string neighbour in towns[thisTown].neighbours.Keys)
            {
                if (towns[neighbour].visited)
                    continue;
                var hopDist = towns[thisTown].neighbours[neighbour];
                var distHome = dynamicDist[thisTown] + hopDist;
                if (distHome < dynamicDist[neighbour]) {
                    dynamicDist[neighbour] = hopDist;
                }
            }
        }

        private static void showConclusion(Dictionary<string, int> dynamicDist)
        {
            foreach (string town in dynamicDist.Keys)
            {
                Console.WriteLine("Dist to {0} is {1}", town, dynamicDist[town]);
            }
        }

        const int HUGE = 999999;
    }
}
