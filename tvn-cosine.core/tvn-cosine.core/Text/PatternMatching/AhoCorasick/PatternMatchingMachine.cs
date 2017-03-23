using System;
using System.Collections.Generic;

namespace tvn.cosine.Text.PatternMatching.AhoCorasick
{
    public class PatternMatchingMachine
    {
        private const string patternMatchFoundActionNullExceptionMessage = "patternMatchFoundAction cannot be null.";
        private const string patternsNullExceptionMessage = "keywords cannot be null or count 0."; 
        private const Node fail = null;

        private readonly Node root = new RootNode();
        private readonly Action<ICollection<IPattern>, uint, IEnumerable<char>> patternMatchFoundAction;
         
        public PatternMatchingMachine(Action<ICollection<IPattern>, uint, IEnumerable<char>> patternMatchFoundAction, ICollection<IPattern> patterns)
        {
            if (patternMatchFoundAction == null)
                throw new ArgumentNullException(patternMatchFoundActionNullExceptionMessage);
            if (patterns == null || patterns.Count == 0)
                throw new ArgumentNullException(patternsNullExceptionMessage);

            this.patternMatchFoundAction = patternMatchFoundAction;
            constructGotoFunction(patterns);
            constructFailureFunction();
        }

        private Node g(Node state, char a)
        {
            if (!state.gotoStateDictionary.ContainsKey(a))
            {
                if (state is RootNode)
                {
                    return state;
                }

                return fail;
            }

            return state.gotoStateDictionary[a]; 
        }

        private Node f(Node state)
        {
            return state.Failure;
        }

        private ICollection<IPattern> output(Node state)
        {
            return state.Output;
        }

        private void constructGotoFunction(ICollection<IPattern> k)
        { 
            foreach (var y in k) enter(y);
        }

        private void constructFailureFunction()
        {
            Queue<Node> queue = new Queue<Node>();
            foreach (var a in root.Edges)
            {
                queue.Enqueue(a);
                a.Failure = root;
            }

            while (queue.Count > 0)
            {
                Node r = queue.Dequeue();
                foreach (var s in r.Edges)
                {
                    var a = s.Value;
                    queue.Enqueue(s);
                    var state = r.Failure;
                    while (g(state, a) == fail) state = state.Failure;
                    s.Failure = g(state, a);

                    foreach (var o in s.Failure.Output)
                    {
                        if (!s.Output.Contains(o))
                        {
                            s.Output.Add(o);
                        }
                    } 
                }
            }
        }

        private void enter(IPattern pattern)
        {
            Node current = root;
            foreach (char a in pattern)
            {
                Node newNode = g(current, a);
                if (newNode == fail ||
                    newNode == root)
                {
                    newNode = new Node(a); 
                    if (!current.gotoStateDictionary.ContainsKey(newNode.Value))
                    {
                        current.gotoStateDictionary[newNode.Value] = newNode;
                    }
                }
                current = newNode;
            }

            if (!current.Output.Contains(pattern))
            {
                current.Output.Add(pattern);
            } 
        }

        public void Match(IEnumerable<char> input, out ICollection<IPattern> patternsMatched)
        {
            patternsMatched = new List<IPattern>();

            patternsMatched.Clear(); 
            var state = root;
            foreach (char a in input)
            { 
                while (g(state, a) == fail) state = f(state);
                state = g(state, a);

                foreach (var pattern in output(state))
                {
                    patternsMatched.Add(pattern);
                }
            }
        }

        public void Match(IEnumerable<char> input)
        {
            uint position = 0;
            var state = root;
            foreach (char a in input)
            {
                while (g(state, a) == fail) state = f(state);
                state = g(state, a);

                if (patternMatchFoundAction != null && output(state).Count > 0)
                {
                    patternMatchFoundAction(output(state), position, input);
                }

                ++position;
            }
        }
    }
}
