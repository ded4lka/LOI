using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LOI
{
    public abstract class Expression
    {
        public abstract Region Evaluate(Dictionary<string, Rectangle> regions, Graphics graphics);
    }

    public class VariableExpression : Expression
    {
        private string name;

        public VariableExpression(string name)
        {
            this.name = name;
        }

        public override Region Evaluate(Dictionary<string, Rectangle> regions, Graphics graphics)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(regions[name]);
            return new Region(path);
        }
    }

    public class AndExpression : Expression
    {
        private Expression left;
        private Expression right;

        public AndExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override Region Evaluate(Dictionary<string, Rectangle> regions, Graphics graphics)
        {
            Region leftRegion = left.Evaluate(regions, graphics);
            Region rightRegion = right.Evaluate(regions, graphics);
            leftRegion.Intersect(rightRegion);
            return leftRegion;
        }
    }

    public class OrExpression : Expression
    {
        private Expression left;
        private Expression right;

        public OrExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override Region Evaluate(Dictionary<string, Rectangle> regions, Graphics graphics)
        {
            Region leftRegion = left.Evaluate(regions, graphics);
            Region rightRegion = right.Evaluate(regions, graphics);
            leftRegion.Union(rightRegion);
            return leftRegion;
        }
    }

    public class DifferenceExpression : Expression
    {
        private Expression left;
        private Expression right;

        public DifferenceExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override Region Evaluate(Dictionary<string, Rectangle> regions, Graphics graphics)
        {
            Region leftRegion = left.Evaluate(regions, graphics);
            Region rightRegion = right.Evaluate(regions, graphics);
            leftRegion.Exclude(rightRegion);
            return leftRegion;
        }
    }

    public class XorExpression : Expression
    {
        private Expression left;
        private Expression right;

        public XorExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override Region Evaluate(Dictionary<string, Rectangle> regions, Graphics graphics)
        {
            Region leftRegion = left.Evaluate(regions, graphics);
            Region rightRegion = right.Evaluate(regions, graphics);
            leftRegion.Xor(rightRegion);
            return leftRegion;
        }
    }

}