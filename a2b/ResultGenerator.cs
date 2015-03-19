﻿using System;
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

            // frontier ← priority queue containing node only
            PriorityQueue<SearchNode> frontier = new PriorityQueue<SearchNode>();
            frontier.Enqueue(startNode);

            // explored ← empty set
            List<SearchNode> explored = new List<SearchNode>();

            // do while frontier is not empty
            while (frontier.Count > 0)
            {
                // node := frontier.pop()
                SearchNode node = (SearchNode)frontier.Dequeue();

                // for each of node's neighbors n
                foreach (SearchNode n in node.Neighbours)
                {

                    // if n is not in explored
                    if (!explored.Contains(n))
                    {
                        // if n is not in frontier
                        if (!frontier.Contains(n))
                        {
                            // frontier.add(n)
                            n.Previous = node;
                            n.Distance = n.DistanceFrom(startNode);
                            frontier.Enqueue(n);
                        }
                        // else if n is in frontier ...
                        else //if (frontier.Contains(n))
                        {
                            // ...with higher cost
                            if (n.Distance > node.Distance)
                            {
                                // replace existing node with n
                                n.Previous = node;
                            }
                        }
                    }
                }

                // explored.add(node)
                explored.Add(node);
            }

            try
            {
                ResultPath solution = new ResultPath();
                SearchNode node = _ss.EndNode;
                
                // return solution
                while (!node.Equals(startNode))
                {
                    solution.Push(node);
                    node = node.Previous;
                }
                solution.Push(node);

                // Need to reverse the stack.
                ResultPath reversed = new ResultPath();
                while (solution.Count > 0)
                {
                    reversed.Push(solution.Pop());
                }
                return reversed;
            }
            catch
            {
                // return failure
                throw new Exception("Cannot find path from start to end.");
            }
        }
    }
}
