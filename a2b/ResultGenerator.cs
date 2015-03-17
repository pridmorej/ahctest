using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ResultGenerator : IResultGenerator
    {
        private SearchStructure _ss;

        public ResultGenerator(SearchStructure searchStructure)
        {
            _ss = searchStructure;
        }

        public ResultPath Generate()
        {
            // node ← start
            SearchNode startNode = _ss.StartNode;

            // cost ← 0
            int cost = 0; // _ss.SearchNodes.Count;
            
            // frontier ← priority queue containing node only
            ResultPath frontier = new ResultPath();
            frontier.Push(startNode);

            // explored ← empty set
            List<SearchNode> explored = new List<SearchNode>();

            ResultPath solution = new ResultPath();

            // do
            while (true)
            {
                // if frontier is empty
                if (frontier.Count == 0)
                {
                    // return failure
                    throw new Exception("Cannot find path from start to finish.");
                }

                // node := frontier.pop()
                SearchNode current = (SearchNode)frontier.Pop();

                // if node is goal
                if (current.Equals(_ss.EndNode))
                {
                    // return solution
                    while (!current.Equals(startNode))
                    {
                        solution.Push(current);
                        current = current.Previous;
                    }
                    solution.Push(current);
                    return solution;
                }

                // explored.add(node)
                explored.Add(current);
                cost++;

                // for each of node's neighbors n
                foreach (SearchNode neighbour in current.Neighbours)
                {

                    // if n is not in explored
                    if (!explored.Contains(neighbour))
                    {
                        // if n is not in frontier
                        if (!frontier.Contains(neighbour))
                        {
                            // frontier.add(n)
                            frontier.Push(neighbour);
                            neighbour.Distance = cost;
                            neighbour.Previous = current;
                        }
                        // else if n is in frontier ...
                        else if (frontier.Contains(neighbour))
                        {
                            // ...with higher cost
                            if (neighbour.Distance > cost)
                            {
                                // replace existing node with n
                                while (!neighbour.Equals((SearchNode)frontier.Peek()))
                                {
                                    frontier.Pop(); // Discard.
                                }
                                current = neighbour;
                                cost = neighbour.Distance;
                            }
                        }
                    }
                }
            }

            /*
            // Need to now perform the actual search.
            startNode.Visited = true;
            shortest.Push(startNode);

            // Are the Start and End the same?  If so, just return the one item on the result stack.
            if (startNode.Equals(_ss.EndNode)) { return shortest; }

            // Need to start searching.
            int distance = 0;


            while (searchCandidates.Count > 0)
            {
                    shortest.Push(neighbour);

                    if (neighbour.Equals(_ss.EndNode))
                    {
                        // Found endnode, so check if the max length found so far is less than the distance travelled.  If so, then found a shorter route.
                        if (current.Distance + 1 < length)
                        {
                            length = current.Distance + 1;
                        }
                        else
                        {
                            // found end node, but distance is longer than shortest found so far.
                        }
                    }
                    else
                    {
                        // Not endnode, so add to stack of search candidates if not already visited.
                        if (!neighbour.Visited)
                        {
                            neighbour.Visited = true;
                            neighbour.Distance = current.Distance + 1;
                            searchCandidates.Push(neighbour);
                        }
                    }

                    shortest.Pop(); // Discard.
                }

                // Once pushed all candidates onto list, pop the next search candidate.
                current = (SearchNode)searchCandidates.Pop();
            }*/

            return solution;
        }
    }
}
