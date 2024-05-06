using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LOI
{
    public class ExpressionEvaluator
    {
        private Dictionary<string, Rectangle> regions;
        private Dictionary<string, HashSet<string>> sets;
        private Panel renderPanel; // Элемент управления для рендеринга графики

        public ExpressionEvaluator(Dictionary<string, Rectangle> regions, Panel renderPanel)
        {
            this.regions = regions; // Словарь с прямоугольниками для каждой переменной
            this.renderPanel = renderPanel; // Panel для рендеринга графики
        }

        public Region Evaluate(Expression expression)
        {
            using (Graphics graphics = renderPanel.CreateGraphics())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias; // Для лучшего качества графики
                return expression.Evaluate(regions, graphics);  // Вызов метода Evaluate для AST
            }
        }
    }
    
    public class NumericalExpressionEvaluator
    {
        private Dictionary<string, HashSet<string>> sets;

        public NumericalExpressionEvaluator(Dictionary<string, HashSet<string>> sets)
        {
            this.sets = sets;
        }

        public HashSet<string> Evaluate(NumericalExpression expression)
        {
            return expression.Evaluate(sets);
        }
    }
}