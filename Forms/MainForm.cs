using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LOI
{
    public partial class MainForm : Form
    {
        private DiagramRenderer diagramRenderer;
        private Utils utils;

        public MainForm()
        {
            InitializeComponent();
            InitializeFormStyle();
            diagramRenderer = new DiagramRenderer(renderPanel);
            utils = new Utils();
        }

        private void InitializeFormStyle()
        {
            BackColor = Color.FromArgb(45, 45, 48);
            ForeColor = Color.White;
            
            InputPanel.BackColor = Color.FromArgb(65, 65, 68);
            SetsPanelBase.BackColor = Color.FromArgb(35, 35, 38);
            ResultPanel.BackColor = Color.FromArgb(35, 35, 38);

            ExecuteButton.BackColor = Color.FromArgb(105, 105, 108);
            AddSetButton.BackColor = Color.FromArgb(105, 105, 108);
            RemoveSetButton.BackColor = Color.FromArgb(105, 105, 108);


            InputExpressionTextBox.BackColor = Color.FromArgb(105, 105, 108);
            InputExpressionTextBox.ForeColor = Color.White;

            label2.Text = "Диграмма Венна:";
            label2.Font = new Font(Font.FontFamily, 12);
            label2.ForeColor = Color.Black;

        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessExpression();

                Status.Text = "Диграмма построена!";
                Status.ForeColor = Color.LightGreen;
                Console.WriteLine("Диграмма построена!");

                //diagramRenderer.UpdateRegions(initialCircles);

            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке
                Status.Text = $"{ex.Message}";
                Status.ForeColor = Color.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private void ProcessExpression()
        {
            string inputExpression = InputExpressionTextBox.Text;
            ExpressionValidator validator = new ExpressionValidator();
            if (validator.Validate(inputExpression))
            {
                if (ValidateSetsCount(inputExpression))
                {
                    UpdateDataCollector();

                    ExpressionParser parser = new ExpressionParser(inputExpression);
                    Expression expression = parser.Parse();

                    NumericalExpressionParser numericalExpressionParser = new NumericalExpressionParser(inputExpression);
                    NumericalExpression numericalExpression = numericalExpressionParser.Parse();


                    Dictionary<string, Rectangle> regions = SetDataCollector.Instance.GetRegions();
                    Dictionary<string, HashSet<string>> numericalSets = SetDataCollector.Instance.GetNumericalSets();

                    ExpressionEvaluator evaluator = new ExpressionEvaluator(regions, renderPanel);
                    NumericalExpressionEvaluator numericalEvaluator = new NumericalExpressionEvaluator(numericalSets);

                    Region resultRegion = evaluator.Evaluate(expression);
                    HashSet<string> resultHashSet = numericalEvaluator.Evaluate(numericalExpression); 

                    PrintResultExpression(resultHashSet);
                    Draw(resultRegion);
                    ColorTextBoxes();
                    Status.Text = "Expression is valid and processed.";
                }
                else
                {
                    Status.Text = "Количество полей и множеств должно совпадать!";
                    throw new Exception("Количество полей и множеств не совпадает!");
                }
            }
            else
            {
                Status.Text = "Выражение не верно!";
                throw new Exception("Выражение не корректно!");
            }


        }

        private List<char> FindUppercaseLetters(string input)
        {
            List<char> result = new List<char>();

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    result.Add(c);
                }
            }

            // Сортировка списка перед возвратом
            result.Sort();

            return result;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            ExecuteButton_Click(sender, e);
        }

        private void Draw(Region region)
        {
            //diagramRenderer.InitializeCircles(5);
            diagramRenderer.SetCircles(SetDataCollector.Instance.GetSets());
            diagramRenderer.DrawRegion(region);
            diagramRenderer.DrawInitialCircles();
        }

        private void PrintResultExpression(HashSet<string> resultHashSet)
        {
            List<string> resultList = resultHashSet.ToList();
            utils.SortStringNumbers(resultList);
            string result = utils.ListToString(resultList);
            ResultLabel.Text = $"Итоговое множество: {result}";
        }
        private void InputPanel_Click(object sender, EventArgs e)
        {
            InputPanel.Focus();
        }

        private void InputExpressionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ExecuteButton_Click(sender, e);
            }
        }

        private void AddSetButton_Click_1(object sender, EventArgs e)
        {
            if (SetsPanel.Controls.Count >= 26)
            {
                MessageBox.Show("Достигнуто максимальное количество множеств.");
                return;
            }
            else
            {
                Panel panel = new Panel();
                panel.Width = SetsPanel.Width - 25;
                panel.Height = 30;
                panel.Margin = new Padding(3);

                Label label = new Label();
                int setIndex = SetsPanel.Controls.Count; // Получаем индекс нового множества
                char setName = (char)('A' + setIndex); // Преобразуем индекс в букву алфавита
                label.Text = "Множество " + setName + ":"; // Используем букву для метки
                label.Width = 85; // Увеличиваем ширину, если нужно, чтобы текст полностью отображался
                label.TextAlign = ContentAlignment.MiddleCenter;

                TextBox textBox = new TextBox();
                textBox.Dock = DockStyle.Right;
                textBox.Width = 150;
                textBox.BackColor = Color.FromArgb(105, 105, 108);
                textBox.ForeColor = Color.White;
                textBox.MaxLength = 30;

                panel.Controls.Add(label);
                panel.Controls.Add(textBox);

                SetsPanel.Controls.Add(panel);
                SetsPanel.ScrollControlIntoView(panel);
            }
        }

        private void RemoveSetButton_Click_1(object sender, EventArgs e)
        {
            if (SetsPanel.Controls.Count > 0)
            {
                SetsPanel.Controls.RemoveAt(SetsPanel.Controls.Count - 1);
            }
        }
        private void UpdateDataCollector()
        {
            List<char> chars = FindUppercaseLetters(InputExpressionTextBox.Text);
            List<Rectangle> rectangles = diagramRenderer.InitializeCircles(chars.Count);
            List<Color> colors = CreateColors(chars.Count);
            List<HashSet<string>> hashsets = GetSets();
            
            SetDataCollector.Instance.Update(chars, rectangles, colors, hashsets);
        }
        private List<Color> CreateColors(int count)
        {
            List<Color> colors = new List<Color>();
            for (int i = 1; i < 27  ; ++i)
            {
                colors.Add(Color.FromArgb(i * 58 % 255, i * 99 % 255, i * 74 % 255));
            }
            return colors;
        }
        private List<HashSet<string>> GetSets()
        {
            List<HashSet<string>> listOfSets = new List<HashSet<string>>();
            foreach (Control panel in SetsPanel.Controls)
            {
                if (panel is Panel)
                {
                    // Предполагаем, что TextBox это второй контрол в панели
                    TextBox textBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null)
                    {
                        // Преобразуем текст в HashSet и добавляем в список
                        HashSet<string> set = utils.StringToHashSet(textBox.Text);
                        listOfSets.Add(set);
                    }
                    else
                    {
                        // Если TextBox не найден, добавляем пустой HashSet
                        listOfSets.Add(new HashSet<string>());
                    }
                }
            }
            return listOfSets;
        }
        private void ColorTextBoxes()
        {
            for (int i = 0; i < SetsPanel.Controls.Count; ++i)
            {
                Label label = SetsPanel.Controls[i].Controls.OfType<Label>().FirstOrDefault();
                TextBox textBox = SetsPanel.Controls[i].Controls.OfType<TextBox>().FirstOrDefault();

                if (label != null)
                {
                    string labelText = label.Text;
                    char lastChar = labelText.LastOrDefault(char.IsLetter);

                    if (lastChar != '\0')
                    {
                        label.ForeColor = SetDataCollector.Instance.GetSets()[i].ColorData;
                    }
                }
            }
        }
        private bool ValidateSetsCount(string input)
        {
            if(SetsPanel.Controls.Count == FindUppercaseLetters(input).Count)
            {
                return true;
            }
            return false;
        }
    }
}
