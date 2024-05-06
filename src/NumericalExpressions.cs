using System.Collections.Generic;

namespace LOI
{
    public abstract class NumericalExpression
    {
        public abstract HashSet<string> Evaluate(Dictionary<string, HashSet<string>> sets);
    }

    public class NumericalVariableExpression : NumericalExpression
    {
        private string name;

        public NumericalVariableExpression(string name)
        {
            this.name = name;
        }

        public override HashSet<string> Evaluate(Dictionary<string, HashSet<string>> sets)
        {
            if (sets.TryGetValue(name, out var set))
            {
                return new HashSet<string>(set);
            }
            return new HashSet<string>();
        }
    }

    public class NumericalAndExpression : NumericalExpression
    {
        private NumericalExpression left;
        private NumericalExpression right;

        public NumericalAndExpression(NumericalExpression left, NumericalExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public override HashSet<string> Evaluate(Dictionary<string, HashSet<string>> sets)
        {
            HashSet<string> leftSet = left.Evaluate(sets);
            HashSet<string> rightSet = right.Evaluate(sets);
            leftSet.IntersectWith(rightSet);
            return leftSet;
        }
    }

    public class NumericalOrExpression : NumericalExpression
    {
        private NumericalExpression left;
        private NumericalExpression right;

        public NumericalOrExpression(NumericalExpression left, NumericalExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public override HashSet<string> Evaluate(Dictionary<string, HashSet<string>> sets)
        {
            HashSet<string> leftSet = left.Evaluate(sets);
            HashSet<string> rightSet = right.Evaluate(sets);
            leftSet.UnionWith(rightSet);
            return leftSet;
        }
    }

    public class NumericalDifferenceExpression : NumericalExpression
    {
        private NumericalExpression left;
        private NumericalExpression right;

        public NumericalDifferenceExpression(NumericalExpression left, NumericalExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public override HashSet<string> Evaluate(Dictionary<string, HashSet<string>> sets)
        {
            HashSet<string> leftSet = left.Evaluate(sets);
            HashSet<string> rightSet = right.Evaluate(sets);
            leftSet.ExceptWith(rightSet);
            return leftSet;
        }
    }

    public class NumericalXorExpression : NumericalExpression
    {
        private NumericalExpression left;
        private NumericalExpression right;

        public NumericalXorExpression(NumericalExpression left, NumericalExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public override HashSet<string> Evaluate(Dictionary<string, HashSet<string>> sets)
        {
            HashSet<string> leftSet = left.Evaluate(sets);
            HashSet<string> rightSet = right.Evaluate(sets);
            leftSet.SymmetricExceptWith(rightSet);
            return leftSet;
        }
    }
}
