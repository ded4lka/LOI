using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace LOI
{
    public class SetDataCollector
    {
        private static SetDataCollector _instance;
        private static readonly object _lock = new object();
        private SetDataCollector() { }
        public static SetDataCollector Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new SetDataCollector();
                }
                return _instance;
            }    
        }

        private List<Set> sets = new List<Set>();
        private Utils utils = new Utils();

        public void Update(List<char> chars, List<Rectangle> rectangles, List<Color> colors, List<HashSet<string>> hashsets)
        {
            sets.Clear();
            for (int i = 0; i<chars.Count;++i)
            {
                sets.Add(new Set(chars[i], rectangles[i], colors[i], hashsets[i]));
            }
            Print();
        }

        public List<Set> GetSets() { return sets; }

        public Dictionary<string, HashSet<string>> GetNumericalSets()
        {
            Dictionary<string, HashSet<string>> numericalSets = new Dictionary<string, HashSet<string>>();
            foreach (Set set in sets)
            {
                numericalSets.Add(set.CharData.ToString(), set.HashSetData);
            }
            return numericalSets;
        }
        public Dictionary<string, Rectangle> GetRegions()
        {
            Dictionary<string, Rectangle> regions = new Dictionary<string, Rectangle>();
            foreach (Set set in sets)
            {
                regions.Add(set.CharData.ToString(), set.RectangleData);
            }
            return regions;
        }

        private void Print()
        {
            foreach (Set set in sets)
            {
                Console.Write($"{set.CharData} : {set.RectangleData} ; {set.ColorData} ; set: {utils.HashSetToString(set.HashSetData)}\n");
            }
        }
    }
}
