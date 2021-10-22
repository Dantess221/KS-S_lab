using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmap_Extensions.Converters
{
    public static class ConvertFromBytes
    {
        private static String HexConverter(Color c)
        {
            String rtn = String.Empty;
            try
            {
                rtn = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            }
            catch (Exception ex)
            {
                //doing nothing
            }

            return rtn;
        }

        public static string Convert(ref Graphics canva, byte[] input) 
        {
            if (input.Length > 0)
            {
                Color color = Color.White;
                switch (input[0])
                {
                    case 0:
                        if(input.Length == 1)
                            BitmapFunctions.ClearDisplay(ref canva, color);
                        else
                        if (input.Length == 4)
                            BitmapFunctions.ClearDisplay(ref canva, color = Color.FromArgb(input[1], input[2], input[3]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"ClearDisplay {HexConverter(color)}";

                    case 1:
                        if (input.Length == 3)
                            BitmapFunctions.Draw_Pixel(ref canva, input[1], input[2], color);
                        else
                        if (input.Length == 6)
                            BitmapFunctions.Draw_Pixel(ref canva, input[1], input[2], color = Color.FromArgb(input[3], input[4], input[5]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Pixel Point({input[1]};{input[2]}) {HexConverter(color)}";

                    case 2:
                        if (input.Length == 5)
                            BitmapFunctions.Draw_Line(ref canva, input[1], input[2], input[3], input[4], color);
                        else
                        if (input.Length == 8)
                            BitmapFunctions.Draw_Line(ref canva, input[1], input[2], input[3], input[4], color = Color.FromArgb(input[5], input[6], input[7]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Line Point1({input[1]};{input[2]}) Point2({input[3]};{input[4]}) {HexConverter(color)}";

                    case 3:
                        if (input.Length == 5)
                            BitmapFunctions.Draw_Rectangle(ref canva, input[1], input[2], input[3], input[4], color);
                        else
                        if (input.Length == 8)
                            BitmapFunctions.Draw_Rectangle(ref canva, input[1], input[2], input[3], input[4], color = Color.FromArgb(input[5], input[6], input[7]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Rectangle Point({input[1]};{input[2]}) Height({input[3]}) Width({input[4]}) {HexConverter(color)}";

                    case 4:
                        if (input.Length == 5)
                            BitmapFunctions.Fill_Rectangle(ref canva, input[1], input[2], input[3], input[4], color);
                        else
                        if (input.Length == 8)
                            BitmapFunctions.Fill_Rectangle(ref canva, input[1], input[2], input[3], input[4], color = Color.FromArgb(input[5], input[6], input[7]));
                        else
                            throw new FormatException("Parameters count is missmatch"); 
                        return $"Fill_Rectangle Point({input[1]};{input[2]}) Height({input[3]}) Width({input[4]}) {HexConverter(color)}";

                    case 5:
                        if (input.Length == 5)
                            BitmapFunctions.Draw_Ellipse(ref canva, input[1], input[2], input[3], input[4], color);
                        else
                        if (input.Length == 8)
                            BitmapFunctions.Draw_Ellipse(ref canva, input[1], input[2], input[3], input[4], color = Color.FromArgb(input[5], input[6], input[7]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Ellipse Point({input[1]};{input[2]}) RadiusX({input[3]}) RadiusY({input[4]}) {HexConverter(color)}";

                    case 6:
                        if (input.Length == 5)
                            BitmapFunctions.Fill_Ellipse(ref canva, input[1], input[2], input[3], input[4], color);
                        else
                        if (input.Length == 8)
                            BitmapFunctions.Fill_Ellipse(ref canva, input[1], input[2], input[3], input[4], color = Color.FromArgb(input[5], input[6], input[7]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Fill_Ellipse Point({input[1]};{input[2]}) RadiusX({input[3]}) RadiusY({input[4]}) {HexConverter(color)}";

                    case 7:
                        if (input.Length == 4)
                            BitmapFunctions.Draw_Circle(ref canva, input[1], input[2], input[3], color);
                        else
                        if (input.Length == 7)
                            BitmapFunctions.Draw_Circle(ref canva, input[1], input[2], input[3], color = Color.FromArgb(input[4], input[5], input[6]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Ellipse Point({input[1]};{input[2]}) Radius({input[3]}) {HexConverter(color)}";

                    case 8:
                        if (input.Length == 4)
                            BitmapFunctions.Fill_Circle(ref canva, input[1], input[2], input[3], color);
                        else
                        if (input.Length == 7)
                            BitmapFunctions.Fill_Circle(ref canva, input[1], input[2], input[3], color = Color.FromArgb(input[4], input[5], input[6]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Fill_Circle Point({input[1]};{input[2]}) Radius({input[3]}) {HexConverter(color)}";

                    case 9:
                        if (input.Length == 6)
                            BitmapFunctions.Draw_Rounded_Rectangle(ref canva, input[1], input[2], input[3], input[4], input[5], color);
                        else
                        if (input.Length == 9)
                            BitmapFunctions.Draw_Rounded_Rectangle(ref canva, input[1], input[2], input[3], input[4], input[5], color = Color.FromArgb(input[6], input[7], input[8]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Rounded_Rectangle Point({input[1]};{input[2]}) Height({input[3]}) Width({input[4]}) Radius({input[5]}) {HexConverter(color)}";

                    case 10:
                        if (input.Length == 6)
                            BitmapFunctions.Fill_Rounded_Rectangle(ref canva, input[1], input[2], input[3], input[4], input[5], color);
                        else
                        if (input.Length == 9)
                            BitmapFunctions.Fill_Rounded_Rectangle(ref canva, input[1], input[2], input[3], input[4], input[5], color = Color.FromArgb(input[6], input[7], input[8]));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Fill_Rounded_Rectangle Point({input[1]};{input[2]}) Height({input[3]}) Width({input[4]}) Radius({input[5]}) {HexConverter(color)}";

                    case 11:
                        if (input.Length > 5)
                            BitmapFunctions.Draw_Text(ref canva, input[1], input[2], input[3], input[4], color, Encoding.UTF8.GetString(input, 8, input.Length - 8));
                        else
                        if (input.Length > 8)
                            BitmapFunctions.Draw_Text(ref canva, input[1], input[2], input[3], input[4], color = Color.FromArgb(input[5], input[6], input[7]), Encoding.UTF8.GetString(input, 8, input.Length - 8));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Text Point({input[1]};{input[2]}) FontSize({input[3]}) Length({input[4]}) {HexConverter(color)} Text:\"{Encoding.UTF8.GetString(input, 8, input.Length - 8)}\"";

                    case 12:
                        if (input.Length > 5)
                            BitmapFunctions.Draw_Image(ref canva, input[1], input[2], input[3], input[4], Image.FromStream(new MemoryStream(input, 5, input.Length - 5)));
                        else
                            throw new FormatException("Parameters count is missmatch");
                        return $"Draw_Image Point({input[1]};{input[2]}) Height({input[3]}) Width({input[4]})";

                    default:
                        throw new NotImplementedException("Command not excist");

                }
            }
            else throw new ArgumentNullException("Input is empty");
            return "";
        }
    }
}
