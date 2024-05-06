using System.Collections.Generic;
using System.Drawing;

namespace LOI
{
    public class Set
    {
        public char CharData { get; set; }
        public Rectangle RectangleData { get; set; }
        public Color ColorData { get; set; }
        public HashSet<string> HashSetData { get; set; }
        public Set(char charData, Rectangle rectangleData, Color colorData, HashSet<string> hashSetData)
        {
            CharData = charData;
            RectangleData = rectangleData;
            ColorData = colorData;
            HashSetData = hashSetData;
        }
    }
}
