using NHAssist.UIs.UIBases;
namespace NHAssist.UIs.ThyPanel
{
    public static class UIDims
    {
        public const int OptionSize = 32;
        public const int OptionSep = 4;
        public const int CategorySep = 4;
        public const int PanelMinWidth = 300;
        public const int PanelMinHeight = 240;

        public static int MaxOptionsPerRow(float rowWidth) => (int)((rowWidth - OptionSep) / (OptionSize + OptionSep));
        //public static CalculatedStyle? StandardRealDimension(UIElement self)
        //{
        //    if (self.Parent == null)
        //        return null;
        //    CalculatedStyle parentStyle;
        //    if (self.Parent is RealDimensional r && r.RealDimension.HasValue)
        //        parentStyle = r.RealDimension.Value;
        //    else
        //        parentStyle = self.Parent.GetInnerDimensions();
        //    CalculatedStyle style = new CalculatedStyle();
        //    style.X = parentStyle.X + self.Left.GetValue(parentStyle.Width);
        //    style.Y = parentStyle.Y + self.Top.GetValue(parentStyle.Height);
        //    style.Width = self.Width.Pixels;
        //    style.Height = self.Height.Pixels;
        //    return style;
        //}
    }
}
