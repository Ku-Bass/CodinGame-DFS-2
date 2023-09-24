using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
        List<Node> nodes = new List<Node>();
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        for (int i = 0; i < N; i++)
        {
            Console.Error.WriteLine("a");
            nodes.Add(new Node());
            nodes.Last().number = i;
        }
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            edges.Add(new Tuple<int, int>(N1, N2));

        }
        List<int> gateway = new List<int>();
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            Console.Error.WriteLine(EI + "gateway");
            nodes[EI].isGateway = true;
        }
        foreach (Tuple<int, int> edge in edges)
        {
            nodes[edge.Item1].neighbours.Add(nodes[edge.Item2]);
            nodes[edge.Item2].neighbours.Add(nodes[edge.Item1]);

        }
        Queue<Node> queue = new Queue<Node>();
        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn
            Node agent = nodes[SI];
            queue.Enqueue(nodes[SI]);
           
            Node GateWay = new Node();
            List<Node> visited = new List<Node>();
            
            bool foundGateWay = false;
            while (foundGateWay == false)
            {
                foreach (Node node in queue.First().neighbours)
                {
                    if (!visited.Contains(node))
                    {
                        queue.Enqueue(node);
                    }
                    if (node.isGateway)
                    {
                        GateWay = node;
                        foundGateWay = true;
                    }


                }
                visited.Add(queue.First());
                queue.Dequeue();
                Console.Error.WriteLine(GateWay.number + "JHEIUFHOIUH");
            }
            Node nodePath = GateWay;
            bool iKnow = false;
            while (!iKnow)
            {
                
                foreach (Node node in visited)
                {   
                    if (nodePath.neighbours.Contains(agent))
                    {
                        Console.WriteLine(nodePath.number + " " + agent.number);
                        nodePath.neighbours.Remove(agent);
                        agent.neighbours.Remove(nodePath);
                        iKnow = true;
                        break;
                    }
                    
                    if (node.neighbours.Contains(nodePath))
                    {
                        nodePath = node;
                        visited.Remove(node);
                        break;
                    }
                    
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // Example: 0 1 are the indices of the nodes you wish to sever the link between

        }
    }
}
class Node
{   
    public Node ()
    {
        neighbours = new List<Node>();
    }
    public int number { get; set; }
    public List<Node> neighbours { get; set; }
    public bool isGateway { get; set; }


}