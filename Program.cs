using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>> {
        {"A", new List<string> {"B", "C"}},
        {"B", new List<string> {"A", "D", "E"}},
        {"C", new List<string> {"A", "F"}},
        {"D", new List<string> {"B"}},
        {"E", new List<string> {"B", "F"}},
        {"F", new List<string> {"C", "E"}}
    };
    static Dictionary<string, string> parents = new Dictionary<string, string>();

    static void BFS(string start, string goal) {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(start);
        parents[start] = null;

        while (queue.Count > 0) {
            string current = queue.Dequeue();

            if (current == goal) {
                PrintPath(goal);
                return;
            }

            foreach (var neighbor in graph[current]) {
                if (!parents.ContainsKey(neighbor)) {
                    parents[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }
        Console.WriteLine("No path found from " + start + " to " + goal);
    }

    static void PrintPath(string current) {
        if (current != null) {
            PrintPath(parents[current]);
            Console.Write(current + " -> ");
        }
    }

    static void Main(string[] args) {
        string start = "A";
        string goal = "F";

        BFS(start, goal);
    }
}
