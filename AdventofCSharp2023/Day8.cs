
using System.Reflection.Metadata.Ecma335;

namespace AdventofCSharp_2023
{
    public static class Day8
    {
        public static int NumberOfStepsToExit(List<string> steps)
        {
            Dictionary<string, Node> directions = CreateNodes(steps);
            var stepDirections = steps[0].ToArray();

            var current = directions["AAA"];
            int stepIdx = 0;
            var stepsTaken = 0;

            while(current.Value != null && current.Value != "ZZZ")
            {
                stepsTaken++;
                if (stepDirections[stepIdx] == 'R')
                {
                    current = current.Right;
                } else
                {
                    current = current.Left;
                }

                stepIdx++;

                if(stepIdx >= stepDirections.Length)
                {
                    stepIdx = 0;
                }
            }

            return stepsTaken;
        }

        public static long NumberOfStepsToGhostExit(List<string> steps)
        {
            Dictionary<string, Node> directions = CreateNodes(steps);
            var stepDirections = steps[0].ToArray();

            var currentSteps = directions.Where(s => s.Key.EndsWith('A')).Select(s => s.Value).ToList();
            int stepIdx = 0;
            var stepsTaken = 0;
            var stepsList = new List<long>();

            while (currentSteps.Count() > 0)
            {
                stepsTaken++;
                if (stepDirections[stepIdx] == 'R')
                {
                    List<Node> nextSteps = new List<Node>();
                    foreach (var step in currentSteps)
                    {
                        if (step.Right.Value.EndsWith('Z'))
                        {
                            stepsList.Add(stepsTaken);
                        } else
                        {
                            nextSteps.Add(step.Right);
                        }
                    }

                    currentSteps = nextSteps;
                }
                else
                {
                    List<Node> nextSteps = new List<Node>();
                    foreach (var step in currentSteps)
                    {
                        if (step.Left.Value.EndsWith('Z'))
                        {
                            stepsList.Add(stepsTaken);
                        }
                        else
                        {
                            nextSteps.Add(step.Left);
                        }
                    }

                    currentSteps = nextSteps;
                }

                stepIdx++;

                if (stepIdx >= stepDirections.Length)
                {
                    stepIdx = 0;
                }
            }

            return LCM(stepsList.Order().ToList());

        }

        private static long GCD(long n1, long n2)
        {
            if (n2 == 0)
            {
                return n1;
            }
            else
            {
                return GCD(n2, n1 % n2);
            }
        }

        private static long LCM(List<long> numbers)
        {
            return numbers.Aggregate((S, val) => S * val / GCD(S, val));
        }

        private static Dictionary<string, Node> CreateNodes(List<string> steps)
        {
            Dictionary<string, Node> directions = new Dictionary<string, Node>();

            for (int i = 2; i < steps.Count; i++)
            {
                var splitInput = steps[i].Split('=');

                var value = splitInput[0].Trim();
                var splitChildren = splitInput[1].Split(',');
                var leftValue = splitChildren[0].Trim().Remove(0, 1);
                var rightValue = splitChildren[1].Remove(splitChildren[1].Length - 1, 1).Trim();
                
                Node? currentNode = null;

                if (directions.ContainsKey(value))
                {
                    currentNode = directions[value];
                } else
                {
                    currentNode = new Node()
                    {
                        Value = value
                    };
                    directions.Add(currentNode.Value, currentNode);
                }

                if (currentNode.Left == null)
                {
                    Node? leftChild = null;
                    if (directions.ContainsKey(leftValue))
                    {
                        leftChild = directions[leftValue];
                    }
                    else
                    {
                        leftChild = new Node()
                        {
                            Value = leftValue
                        };
                        directions.Add(leftChild.Value, leftChild);
                    }
                    currentNode.Left = leftChild;
                }

                if (currentNode.Right == null)
                {
                    Node? rightChild = null;

                    if (directions.ContainsKey(rightValue))
                    {
                        rightChild = directions[rightValue];
                    }
                    else
                    {
                        rightChild = new Node()
                        {
                            Value = rightValue
                        };
                        directions.Add(rightChild.Value, rightChild);
                    }
                    currentNode.Right = rightChild;
                }

                directions[currentNode.Value] = currentNode;

            }


            return directions;
        }


        private class Node
        {
            public Node? Left { get;  set; }
            public Node? Right { get; set; }

            public string? Value { get; set; }
        }
    }
}
