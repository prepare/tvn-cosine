namespace tvn.cosine.Imaging
{
    /// <summary>
    /// Implementation of IColor.
    /// </summary>
    public class Color : IColor
    {
        #region ctors
        /// <summary>
        /// Creates a new instance of the color class
        /// </summary>
        /// <param name="a">The alpha component</param>
        /// <param name="g">The green component</param>
        /// <param name="b">The blue component</param>
        /// <param name="r">The red component</param>
        public Color(byte a, byte g, byte b, byte r)
        {
            A = a;
            B = b;
            G = g;
            R = r;
        }

        /// <summary>
        /// Creates a new instance of the color class
        /// </summary>
        /// <param name="a">The alpha component</param>
        /// <param name="g">The green component</param>
        /// <param name="b">The blue component</param>
        /// <param name="r">The red component</param>
        /// <param name="name">The name of the color</param>
        private Color(byte a, byte g, byte b, byte r, string name)
            : this(a, g, b, r)
        {
            Name = name; 
        }
        #endregion

        /// <summary>
        ///The alpha component.
        /// </summary>
        public byte A { get; }

        /// <summary>
        /// The blue component.
        /// </summary>
        public byte B { get; }

        /// <summary>
        /// The green component.
        /// </summary>
        public byte G { get; }

        /// <summary>
        /// The red component.
        /// </summary>
        public byte R { get; }

        /// <summary>
        /// The string name of the color.
        /// </summary>
        public string Name { get; }

        #region Static Implementations
        public static Color AliceBlue = new Color(0xFF, 0xF8, 0xFF, 0xF0, "AliceBlue");
        public static Color AntiqueWhite = new Color(0xFF, 0xEB, 0xD7, 0xFA, "AntiqueWhite");
        public static Color Aqua = new Color(0xFF, 0xFF, 0xFF, 0x00, "Aqua");
        public static Color Aquamarine = new Color(0xFF, 0xFF, 0xD4, 0x7F, "Aquamarine");
        public static Color Azure = new Color(0xFF, 0xFF, 0xFF, 0xF0, "Azure");
        public static Color Beige = new Color(0xFF, 0xF5, 0xDC, 0xF5, "Beige");
        public static Color Bisque = new Color(0xFF, 0xE4, 0xC4, 0xFF, "Bisque");
        public static Color Black = new Color(0xFF, 0x00, 0x0, 0x0, "Black");
        public static Color BlanchedAlmond = new Color(0xFF, 0xEB, 0xCD, 0xFF, "BlanchedAlmond");
        public static Color Blue = new Color(0xFF, 0x00, 0xFF, 0x00, "Blue");
        public static Color BlueViolet = new Color(0xFF, 0x2B, 0xE2, 0x8A, "BlueViolet");
        public static Color Brown = new Color(0xFF, 0x2A, 0x2A, 0xA5, "Brown");
        public static Color BurlyWood = new Color(0xFF, 0xB8, 0x87, 0xDE, "BurlyWood");
        public static Color CadetBlue = new Color(0xFF, 0x9E, 0xA0, 0x5F, "CadetBlue");
        public static Color Chartreuse = new Color(0xFF, 0xFF, 0x00, 0x7F, "Chartreuse");
        public static Color Chocolate = new Color(0xFF, 0x69, 0x1E, 0xD2, "Chocolate");
        public static Color Coral = new Color(0xFF, 0x7F, 0x50, 0xFF, "Coral");
        public static Color CornflowerBlue = new Color(0xFF, 0x95, 0xED, 0x64, "CornflowerBlue");
        public static Color Cornsilk = new Color(0xFF, 0xF8, 0xDC, 0xFF, "Cornsilk");
        public static Color Crimson = new Color(0xFF, 0x14, 0x3C, 0xDC, "Crimson");
        public static Color Cyan = new Color(0xFF, 0xFF, 0xFF, 0x00, "Cyan");
        public static Color DarkBlue = new Color(0xFF, 0x00, 0x8B, 0x00, "DarkBlue");
        public static Color DarkCyan = new Color(0xFF, 0x8B, 0x8B, 0x00, "DarkCyan");
        public static Color DarkGoldenRod = new Color(0xFF, 0x86, 0x0B, 0xB8, "DarkGoldenRod");
        public static Color DarkGray = new Color(0xFF, 0xA9, 0xA9, 0xA9, "DarkGray");
        public static Color DarkGreen = new Color(0xFF, 0x00, 0x00, 0x64, "DarkGreen");
        public static Color DarkKhaki = new Color(0xFF, 0xB7, 0x6B, 0xBD, "DarkKhaki");
        public static Color DarkMagenta = new Color(0xFF, 0x00, 0x8B, 0x8B, "DarkMagenta");
        public static Color DarkOliveGreen = new Color(0xFF, 0x6B, 0x2F, 0x55, "DarkOliveGreen");
        public static Color DarkOrange = new Color(0xFF, 0x8C, 0x00, 0xFF, "DarkOrange");
        public static Color DarkOrchid = new Color(0xFF, 0x32, 0xCC, 0x99, "DarkOrchid");
        public static Color DarkRed = new Color(0xFF, 0x00, 0x00, 0x8B, "DarkRed");
        public static Color DarkSalmon = new Color(0xFF, 0x96, 0x7A, 0xE9, "DarkSalmon");
        public static Color DarkSeaGreen = new Color(0xFF, 0xBC, 0x8F, 0x8F, "DarkSeaGreen");
        public static Color DarkSlateBlue = new Color(0xFF, 0x3D, 0x8B, 0x48, "DarkSlateBlue");
        public static Color DarkSlateGray = new Color(0xFF, 0x4F, 0x4F, 0x2F, "DarkSlateGray");
        public static Color DarkSlateGrey = new Color(0xFF, 0x4F, 0x4F, 0x2F, "DarkSlateGrey");
        public static Color DarkTurquoise = new Color(0xFF, 0xCE, 0xD1, 0x00, "DarkTurquoise");
        public static Color DarkViolet = new Color(0xFF, 0x00, 0xD3, 0x94, "DarkViolet");
        public static Color DeepPink = new Color(0xFF, 0x14, 0x93, 0xFF, "DeepPink");
        public static Color DeepSkyBlue = new Color(0xFF, 0xBF, 0xFF, 0x00, "DeepSkyBlue");
        public static Color DimGray = new Color(0xFF, 0x69, 0x69, 0x69, "DimGray");
        public static Color DodgerBlue = new Color(0xFF, 0x90, 0xFF, 0x1E, "DodgerBlue");
        public static Color FireBrick = new Color(0xFF, 0x22, 0x22, 0xB2, "FireBrick");
        public static Color FloralWhite = new Color(0xFF, 0xFA, 0xF0, 0xFF, "FloralWhite");
        public static Color ForestGreen = new Color(0xFF, 0x8B, 0x22, 0x22, "ForestGreen");
        public static Color Fuchsia = new Color(0xFF, 0x00, 0xFF, 0xFF, "Fuchsia");
        public static Color Gainsboro = new Color(0xFF, 0xDC, 0xDC, 0xDC, "Gainsboro");
        public static Color GhostWhite = new Color(0xFF, 0xF8, 0xFF, 0xF8, "GhostWhite");
        public static Color Gold = new Color(0xFF, 0xD7, 0x00, 0xFF, "Gold");
        public static Color GoldenRod = new Color(0xFF, 0xA5, 0x20, 0xDA, "GoldenRod");
        public static Color Gray = new Color(0xFF, 0x80, 0x80, 0x80, "Gray");
        public static Color Green = new Color(0xFF, 0x00, 0x00, 0x80, "Green");
        public static Color GreenYellow = new Color(0xFF, 0xFF, 0x2F, 0xAD, "GreenYellow");
        public static Color HoneyDew = new Color(0xFF, 0xFF, 0xF0, 0xF0, "HoneyDew");
        public static Color HotPink = new Color(0xFF, 0x69, 0xB4, 0xFF, "HotPink");
        public static Color IndianRed = new Color(0xFF, 0x5C, 0x5C, 0xCD, "IndianRed");
        public static Color Indigo = new Color(0xFF, 0x00, 0x82, 0x4B, "Indigo");
        public static Color Ivory = new Color(0xFF, 0xFF, 0xF0, 0xFF, "Ivory");
        public static Color Khaki = new Color(0xFF, 0xE6, 0x8C, 0xF0, "Khaki");
        public static Color Lavender = new Color(0xFF, 0xE6, 0xFA, 0xE6, "Lavender");
        public static Color LavenderBlush = new Color(0xFF, 0xF0, 0xF5, 0xFF, "LavenderBlush");
        public static Color LawnGreen = new Color(0xFF, 0xFC, 0x00, 0x7C, "LawnGreen");
        public static Color LemonChiffon = new Color(0xFF, 0xFA, 0xCD, 0xFF, "LemonChiffon");
        public static Color LightBlue = new Color(0xFF, 0xD8, 0xE6, 0xAD, "LightBlue");
        public static Color LightCoral = new Color(0xFF, 0x80, 0x80, 0xF0, "LightCoral");
        public static Color LightCyan = new Color(0xFF, 0xFF, 0xFF, 0xE0, "LightCyan");
        public static Color LightGoldenRodYellow = new Color(0xFF, 0xFA, 0xD2, 0xFA, "LightGoldenRodYellow");
        public static Color LightGray = new Color(0xFF, 0xD3, 0xD3, 0xD3, "LightGray");
        public static Color LightGreen = new Color(0xFF, 0xEE, 0x90, 0x90, "LightGreen");
        public static Color LightPink = new Color(0xFF, 0xB6, 0xC1, 0xFF, "LightPink");
        public static Color LightSalmon = new Color(0xFF, 0xA0, 0x7A, 0xFF, "LightSalmon");
        public static Color LightSeaGreen = new Color(0xFF, 0xB2, 0xAA, 0x20, "LightSeaGreen");
        public static Color LightSkyBlue = new Color(0xFF, 0xCE, 0xFA, 0x87, "LightSkyBlue");
        public static Color LightSlateGray = new Color(0xFF, 0x88, 0x99, 0x77, "LightSlateGray");
        public static Color LightSteelBlue = new Color(0xFF, 0xC4, 0xDE, 0xB0, "LightSteelBlue");
        public static Color LightYellow = new Color(0xFF, 0xFF, 0xE0, 0xFF, "LightYellow");
        public static Color Lime = new Color(0xFF, 0xFF, 0x00, 0x00, "Lime");
        public static Color LimeGreen = new Color(0xFF, 0xCD, 0x32, 0x32, "LimeGreen");
        public static Color Linen = new Color(0xFF, 0xF0, 0xE6, 0xFA, "Linen");
        public static Color Magenta = new Color(0xFF, 0x00, 0xFF, 0xFF, "Magenta");
        public static Color Maroon = new Color(0xFF, 0x00, 0x00, 0x80, "Maroon");
        public static Color MediumAquaMarine = new Color(0xFF, 0xCD, 0xAA, 0x66, "MediumAquaMarine");
        public static Color MediumBlue = new Color(0xFF, 0x00, 0xCD, 0x00, "MediumBlue");
        public static Color MediumOrchid = new Color(0xFF, 0x55, 0xD3, 0xBA, "MediumOrchid");
        public static Color MediumPurple = new Color(0xFF, 0x70, 0xDB, 0x93, "MediumPurple");
        public static Color MediumSeaGreen = new Color(0xFF, 0xB3, 0x71, 0x3C, "MediumSeaGreen");
        public static Color MediumSlateBlue = new Color(0xFF, 0x68, 0xEE, 0x7B, "MediumSlateBlue");
        public static Color MediumSpringGreen = new Color(0xFF, 0xFA, 0x9A, 0x00, "MediumSpringGreen");
        public static Color MediumTurquoise = new Color(0xFF, 0xD1, 0xCC, 0x48, "MediumTurquoise");
        public static Color MediumVioletRed = new Color(0xFF, 0x15, 0x85, 0xC7, "MediumVioletRed");
        public static Color MidnightBlue = new Color(0xFF, 0x19, 0x70, 0x19, "MidnightBlue");
        public static Color MintCream = new Color(0xFF, 0xFF, 0xFA, 0xF5, "MintCream");
        public static Color MistyRose = new Color(0xFF, 0xE4, 0xE1, 0xFF, "MistyRose");
        public static Color Moccasin = new Color(0xFF, 0xE4, 0xB5, 0xFF, "Moccasin");
        public static Color NavajoWhite = new Color(0xFF, 0xDE, 0xAD, 0xFF, "NavajoWhite");
        public static Color Navy = new Color(0xFF, 0x00, 0x80, 0x80, "Navy");
        public static Color OldLace = new Color(0xFF, 0xF5, 0xE6, 0xFD, "OldLace");
        public static Color Olive = new Color(0xFF, 0x80, 0x00, 0x80, "Olive");
        public static Color OliveDrab = new Color(0xFF, 0x8E, 0x23, 0x6B, "OliveDrab");
        public static Color Orange = new Color(0xFF, 0xA5, 0x00, 0xFF, "Orange");
        public static Color OrangeRed = new Color(0xFF, 0x45, 0x00, 0xFF, "OrangeRed");
        public static Color Orchid = new Color(0xFF, 0x70, 0xD6, 0xDA, "Orchid");
        public static Color PaleGoldenRod = new Color(0xFF, 0xE8, 0xAA, 0xEE, "PaleGoldenRod");
        public static Color PaleGreen = new Color(0xFF, 0xFB, 0x98, 0x98, "PaleGreen");
        public static Color PaleTurquoise = new Color(0xFF, 0xEE, 0xEE, 0xAF, "PaleTurquoise");
        public static Color PaleVioletRed = new Color(0xFF, 0x70, 0x93, 0xDB, "PaleVioletRed");
        public static Color PapayaWhip = new Color(0xFF, 0xEF, 0xD5, 0xFF, "PapayaWhip");
        public static Color PeachPuff = new Color(0xFF, 0xDA, 0xB9, 0xFF, "PeachPuff");
        public static Color Peru = new Color(0xFF, 0x85, 0x3F, 0xCD, "Peru");
        public static Color Pink = new Color(0xFF, 0xC0, 0xCB, 0xFF, "Pink");
        public static Color Plum = new Color(0xFF, 0xA0, 0xDD, 0xDD, "Plum");
        public static Color PowderBlue = new Color(0xFF, 0xE0, 0xE6, 0xB0, "PowderBlue");
        public static Color Purple = new Color(0xFF, 0x00, 0x80, 0x80, "Purple");
        public static Color RebeccaPurple = new Color(0xFF, 0x33, 0x99, 0x66, "RebeccaPurple");
        public static Color Red = new Color(0xFF, 0x00, 0x00, 0xFF, "Red");
        public static Color RosyBrown = new Color(0xFF, 0x8F, 0x8F, 0xBC, "RosyBrown");
        public static Color RoyalBlue = new Color(0xFF, 0x69, 0x90, 0x41, "RoyalBlue");
        public static Color SaddleBrown = new Color(0xFF, 0x45, 0x13, 0x8B, "SaddleBrown");
        public static Color Salmon = new Color(0xFF, 0x80, 0x72, 0xFA, "Salmon");
        public static Color SandyBrown = new Color(0xFF, 0xA4, 0x60, 0xF4, "SandyBrown");
        public static Color SeaGreen = new Color(0xFF, 0x8B, 0x57, 0x2E, "SeaGreen");
        public static Color SeaShell = new Color(0xFF, 0xF5, 0xEE, 0xFF, "SeaShell");
        public static Color Sienna = new Color(0xFF, 0x52, 0x2D, 0xA0, "Sienna");
        public static Color Silver = new Color(0xFF, 0xC0, 0xC0, 0xC0, "Silver");
        public static Color SkyBlue = new Color(0xFF, 0xCE, 0xEB, 0x87, "SkyBlue");
        public static Color SlateBlue = new Color(0xFF, 0x5A, 0xCD, 0x6A, "SlateBlue");
        public static Color SlateGray = new Color(0xFF, 0x80, 0x90, 0x70, "SlateGray");
        public static Color Snow = new Color(0xFF, 0xFA, 0xFA, 0xFF, "Snow");
        public static Color SpringGreen = new Color(0xFF, 0xFF, 0x7F, 0x00, "SpringGreen");
        public static Color SteelBlue = new Color(0xFF, 0x82, 0xB4, 0x46, "SteelBlue");
        public static Color Tan = new Color(0xFF, 0xB4, 0x8C, 0xD2, "Tan");
        public static Color Teal = new Color(0xFF, 0x80, 0x80, 0x80, "Teal");
        public static Color Thistle = new Color(0xFF, 0xBF, 0xD8, 0xD8, "Thistle");
        public static Color Tomato = new Color(0xFF, 0x63, 0x47, 0xFF, "Tomato");
        public static Color Turquoise = new Color(0xFF, 0xE0, 0xD0, 0x40, "Turquoise");
        public static Color Violet = new Color(0xFF, 0x82, 0xEE, 0xEE, "Violet");
        public static Color Wheat = new Color(0xFF, 0xDE, 0xB3, 0xF5, "Wheat");
        public static Color White = new Color(0xFF, 0xFF, 0xFF, 0xFF, "White");
        public static Color WhiteSmoke = new Color(0xFF, 0xF5, 0xF5, 0xF5, "WhiteSmoke");
        public static Color Yellow = new Color(0xFF, 0xFF, 0x00, 0xFF, "Yellow");
        public static Color YellowGreen = new Color(0xFF, 0xCD, 0x32, 0x9A, "YellowGreen");
        #endregion
    }
}
