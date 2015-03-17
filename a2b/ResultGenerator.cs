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

                    // Need to reverse the stack.
                    ResultPath reversed = new ResultPath();
                    while (solution.Count > 0)
                    {
                        reversed.Push(solution.Pop());
                    }
                    return reversed;
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
                            if (neighbour.Distance < cost)
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
        }
    }
}
