using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Drawing;

namespace FCM_Test
{
    /// <summary>
    ///显示消息的坐标是窗口还是图像
    /// </summary>
    public enum Position
    {
        /// <summary>
        ///坐标做为窗口坐标
        /// </summary>
        window,
        /// <summary>
        ///坐标做为图像坐标
        /// </summary>
        image
    }
    /// <summary>
    ///字体显示颜色
    /// </summary>
    public enum FontColor
    {
        /// <summary>
        ///黑色
        /// </summary>
        black,
        /// <summary>
        ///蓝色
        /// </summary>
        blue,
        /// <summary>
        ///黄色
        /// </summary>
        yellow,
        /// <summary>
        ///红色
        /// </summary>
        red,
        ///  /// <summary>
        ///绿色
        /// </summary>
        green,
        ///  /// <summary>
        ///浅蓝
        /// </summary>
        cyan,


        /// <summary>
        ///浅红
        /// </summary>
        coral,

        /// <summary>
        ///白色
        /// </summary>
        white,
        /// <summary>
        ///灰色
        /// </summary>
        gray
    }
    /// <summary>
    /// 显示类
    /// </summary>
    public class RecordDisplay
    {
        private HWindowControl mWindowHandle = null;
        private HTuple m_ImageRow0 = null, m_ImageCol0 = null, m_ImageRow1 = null, m_ImageCol1 = null;
        /// <summary>
        ///初始化类
        /// </summary>
        public RecordDisplay(HWindowControl WindowHandle)
        {
            mWindowHandle = WindowHandle;
            HOperatorSet.SetDraw(mWindowHandle.HalconWindow, "margin");
            HOperatorSet.GenEmptyObj(out mImage);

        }
        private HObject mImage = null;
        /// <summary>
        ///显示图片
        /// </summary>
        public HObject Image
        {
            get
            {
                return mImage;
            }
            set
            {
                try
                {
                    HObject image = null;
                    HOperatorSet.GenEmptyObj(out image);
                    HTuple isEqual = null;
                    HOperatorSet.TestEqualObj(image, value, out isEqual);
                    image.Dispose();
                    if (isEqual == 0)
                    {
                        mImage = value;
                        HTuple hv_HeightWin = null, hv_WidthWin = null;
                        HOperatorSet.GetImageSize(value, out hv_WidthWin, out hv_HeightWin);
                        HOperatorSet.SetPart(mWindowHandle.HalconWindow, 0, 0, hv_HeightWin, hv_WidthWin);
                        HOperatorSet.DispObj(mImage, mWindowHandle.HalconWindow);
                        Rectangle rect = mWindowHandle.ImagePart;
                        rect.Y = m_ImageRow0 = 0;
                        rect.X = m_ImageCol0 = 0;
                        rect.Height = m_ImageRow1 = hv_HeightWin;
                        rect.Width = m_ImageCol1 = hv_WidthWin;
                        mWindowHandle.ImagePart = rect;
                    }
                }
                catch (Exception ex)
                {


                }
            }
        }
        /// <summary>
        ///清除显示
        /// </summary>
        public void Clear()
        {
            mWindowHandle.HalconWindow.ClearWindow();
        }



        //public void DrawCircle(out Circle region)
        //{
        //    HOperatorSet.SetColor(mWindowHandle.HalconWindow, "green");
        //    HOperatorSet.SetDraw(mWindowHandle.HalconWindow, "margin");
        //    HOperatorSet.SetLineWidth(mWindowHandle.HalconWindow, 1);
        //    HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null, hv_Column2 = null, hv_phi = null;


        //    //HOperatorSet.DrawRectangle2(mWindowHandle.HalconWindow, out hv_Row1, out hv_Column1, out hv_phi, out hv_Row2, out hv_Column2);
        //    //RectAffine rect = new RectAffine();
        //    //rect.hv_Column1 = hv_Column1;
        //    //rect.hv_Row1 = hv_Row1;
        //    //rect.hv_Column2 = hv_Column2;
        //    //rect.hv_Row2 = hv_Row2;
        //    //rect.hv_phi = hv_phi;
        //    //region = rect;
        //}




        public void DrawRect(out Rect region)
        {
            HOperatorSet.SetColor(mWindowHandle.HalconWindow, "green");
            HOperatorSet.SetDraw(mWindowHandle.HalconWindow, "margin");
            HOperatorSet.SetLineWidth(mWindowHandle.HalconWindow, 1);
            HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null, hv_Column2 = null;
            HOperatorSet.DrawRectangle1(mWindowHandle.HalconWindow, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2);
            Rect rect = new Rect();
            rect.hv_Column1 = hv_Column1.D;
            rect.hv_Row1 = hv_Row1.D;
            rect.hv_Column2 = hv_Column2.D;
            rect.hv_Row2 = hv_Row2.D;
            region = rect;
        }

        public void DrawRectAff(out RectAffine region)
        {
            HOperatorSet.SetColor(mWindowHandle.HalconWindow, "green");
            HOperatorSet.SetDraw(mWindowHandle.HalconWindow, "margin");
            HOperatorSet.SetLineWidth(mWindowHandle.HalconWindow, 1);
            HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null, hv_Column2 = null, hv_phi = null;
            HOperatorSet.DrawRectangle2(mWindowHandle.HalconWindow, out hv_Row1, out hv_Column1, out hv_phi, out hv_Row2, out hv_Column2);
            RectAffine rect = new RectAffine();
            rect.hv_Column1 = hv_Column1.D;
            rect.hv_Row1 = hv_Row1.D;
            rect.hv_Column2 = hv_Column2.D;
            rect.hv_Row2 = hv_Row2.D;
            rect.hv_phi = hv_phi;
            region = rect;
        }

        /// <summary>
        ///显示区域
        /// </summary>
        public void DisplayRegion(HObject region, FontColor Color)
        {
            if (region != null)
            {
                HOperatorSet.SetColor(mWindowHandle.HalconWindow, Color.ToString());
                HOperatorSet.DispObj(region, mWindowHandle.HalconWindow);
            }
        }
        /// <summary>
        ///显示消息
        /// </summary>
        public void Message(string text, Position pos, double x, double y, FontColor Color, bool Box, string fontsize)
        {

            try
            {


                // Local iconic variables 

                // Local control variables 
                HTuple hv_String = null, hv_CoordSystem = null, hv_Row = null, hv_Column = null, hv_Color = null, hv_Box = null;
                hv_String = text;
                hv_CoordSystem = pos.ToString();
                hv_Row = y;
                hv_Column = x;
                hv_Color = Color.ToString().Replace('_', ' ');
                hv_Box = Box.ToString().ToLower();
                HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
                HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
                HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
                HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
                HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
                HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
                HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
                HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
                HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
                HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
                HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
                HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
                HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
                HTuple hv_CurrentColor = new HTuple();
                HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
                HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
                HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
                HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
                HTuple hv_String_COPY_INP_TMP = hv_String.Clone();


                // Initialize local and output iconic variables 
                //This procedure displays text in a graphics window.
                //
                //Input parameters:
                //WindowHandle: The WindowHandle of the graphics window, where
                //   the message should be displayed
                //String: A tuple of strings containing the text message to be displayed
                //CoordSystem: If set to 'window', the text position is given
                //   with respect to the window coordinate system.
                //   If set to 'image', image coordinates are used.
                //   (This may be useful in zoomed images.)
                //Row: The row coordinate of the desired text position
                //   If set to -1, a default value of 12 is used.
                //Column: The column coordinate of the desired text position
                //   If set to -1, a default value of 12 is used.
                //Color: defines the color of the text as string.
                //   If set to [], '' or 'auto' the currently set color is used.
                //   If a tuple of strings is passed, the colors are used cyclically
                //   for each new textline.
                //Box: If Box[0] is set to 'true', the text is written within an orange box.
                //     If set to' false', no box is displayed.
                //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
                //       the text is written in a box of that color.
                //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
                //       'true' -> display a shadow in a default color
                //       'false' -> display no shadow (same as if no second value is given)
                //       otherwise -> use given string as color string for the shadow color
                //
                //Prepare window
                HOperatorSet.GetRgb(mWindowHandle.HalconWindow, out hv_Red, out hv_Green, out hv_Blue);
                HOperatorSet.GetPart(mWindowHandle.HalconWindow, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
                    out hv_Column2Part);
                HOperatorSet.GetWindowExtents(mWindowHandle.HalconWindow, out hv_RowWin, out hv_ColumnWin,
                    out hv_WidthWin, out hv_HeightWin);
                HOperatorSet.SetPart(mWindowHandle.HalconWindow, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
                //
                //default settings
                if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Row_COPY_INP_TMP = 12;
                }
                if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Column_COPY_INP_TMP = 12;
                }
                if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
                {
                    hv_Color_COPY_INP_TMP = "";
                }
                //
                hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
                //
                //Estimate extentions of text depending on font size.
                HOperatorSet.GetFontExtents(mWindowHandle.HalconWindow, out hv_MaxAscent, out hv_MaxDescent,
                    out hv_MaxWidth, out hv_MaxHeight);
                if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
                {
                    hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                    hv_C1 = hv_Column_COPY_INP_TMP.Clone();
                }
                else
                {
                    //Transform image to window coordinates
                    hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                    hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                    hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                    hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
                }
                //
                //Display text box depending on text size
                hv_UseShadow = 1;
                hv_ShadowColor = "gray";
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
                {
                    if (hv_Box_COPY_INP_TMP == null)
                        hv_Box_COPY_INP_TMP = new HTuple();
                    hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                    hv_ShadowColor = "#f28d26";
                }
                if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                    1))) != 0)
                {
                    if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                    {
                        //Use default ShadowColor set above
                    }
                    else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                        "false"))) != 0)
                    {
                        hv_UseShadow = 0;
                    }
                    else
                    {
                        hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                        //Valid color?
                        try
                        {
                            HOperatorSet.SetColor(mWindowHandle.HalconWindow, hv_Box_COPY_INP_TMP.TupleSelect(
                                1));
                        }
                        // catch (Exception) 
                        catch (HalconException HDevExpDefaultException1)
                        {
                            HDevExpDefaultException1.ToHTuple(out hv_Exception);
                            hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                            throw new HalconException(hv_Exception);
                        }
                    }
                }
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
                {
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(mWindowHandle.HalconWindow, hv_Box_COPY_INP_TMP.TupleSelect(0));
                    }
                    // catch (Exception) 
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                    //Calculate box extents
                    hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                    hv_Width = new HTuple();
                    for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                        )) - 1); hv_Index = (int)hv_Index + 1)
                    {
                        HOperatorSet.GetStringExtents(mWindowHandle.HalconWindow, hv_String_COPY_INP_TMP.TupleSelect(
                            hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                        hv_Width = hv_Width.TupleConcat(hv_W);
                    }
                    hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                        ));
                    hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                    hv_R2 = hv_R1 + hv_FrameHeight;
                    hv_C2 = hv_C1 + hv_FrameWidth;
                    //Display rectangles
                    HOperatorSet.GetDraw(mWindowHandle.HalconWindow, out hv_DrawMode);
                    HOperatorSet.SetDraw(mWindowHandle.HalconWindow, "fill");
                    //Set shadow color
                    HOperatorSet.SetColor(mWindowHandle.HalconWindow, hv_ShadowColor);
                    if ((int)(hv_UseShadow) != 0)
                    {
                        HOperatorSet.DispRectangle1(mWindowHandle.HalconWindow, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
                    }
                    //Set box color
                    HOperatorSet.SetColor(mWindowHandle.HalconWindow, hv_Box_COPY_INP_TMP.TupleSelect(0));
                    HOperatorSet.DispRectangle1(mWindowHandle.HalconWindow, hv_R1, hv_C1, hv_R2, hv_C2);
                    HOperatorSet.SetDraw(mWindowHandle.HalconWindow, hv_DrawMode);
                }
                //Write text.
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                        )));
                    if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                        "auto")))) != 0)
                    {
                        HOperatorSet.SetColor(mWindowHandle.HalconWindow, hv_CurrentColor);
                    }
                    else
                    {
                        HOperatorSet.SetRgb(mWindowHandle.HalconWindow, hv_Red, hv_Green, hv_Blue);
                    }
                    hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                    HOperatorSet.SetTposition(mWindowHandle.HalconWindow, hv_Row_COPY_INP_TMP, hv_C1);

                    // HTuple hv_Font = new HTuple();
                    // HOperatorSet.QueryFont(mWindowHandle.HalconWindow, out hv_Font);
                    //HTuple hv_FontWithStyleAndSize = new HTuple();
                    // hv_FontWithStyleAndSize = "-40-";

                    // //hv_FontWithStyleAndSize = "Courier New-Bold-"+ fontsize;(hv_Font.TupleSelect(0)) +
                    // HOperatorSet.SetFont(mWindowHandle.HalconWindow, hv_FontWithStyleAndSize);

                    HOperatorSet.WriteString(mWindowHandle.HalconWindow, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index));
                }
                //Reset changed window settings
                HOperatorSet.SetRgb(mWindowHandle.HalconWindow, hv_Red, hv_Green, hv_Blue);
                HOperatorSet.SetPart(mWindowHandle.HalconWindow, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                    hv_Column2Part);

                return;
            }
            catch (Exception ex)
            {


            }
        }
        /// <summary>
        ///放大
        /// </summary>
        public void ZoomOut(double X, double Y)
        {
            try
            {
                if (m_ImageRow0 == null)
                {
                    HTuple hv_HeightWin = null, hv_WidthWin = null;
                    HOperatorSet.GetImageSize(mImage, out hv_WidthWin, out hv_HeightWin);
                    m_ImageRow0 = 0;
                    m_ImageCol0 = 0;
                    m_ImageRow1 = hv_HeightWin;
                    m_ImageCol1 = hv_WidthWin;
                }
                HTuple Row0_1, Row1_1, Col0_1, Col1_1;
                Row0_1 = m_ImageRow0 + (Y - mWindowHandle.ImagePart.Y) * 0.05;
                Row1_1 = m_ImageRow1 - (mWindowHandle.ImagePart.Height - Y) * 0.05;
                Col0_1 = m_ImageCol0 + (X - mWindowHandle.ImagePart.X) * 0.05;
                Col1_1 = m_ImageCol1 - (mWindowHandle.ImagePart.Width - X) * 0.05;
                mWindowHandle.HalconWindow.ClearWindow();
                HOperatorSet.SetPart(mWindowHandle.HalconWindow, Row0_1, Col0_1, Row1_1, Col1_1);
                HOperatorSet.DispObj(mImage, mWindowHandle.HalconWindow);
                m_ImageRow0 = Row0_1;
                m_ImageCol0 = Col0_1;
                m_ImageRow1 = Row1_1;
                m_ImageCol1 = Col1_1;
            }
            catch
            {

            }
        }
        /// <summary>
        ///缩小
        /// </summary>
        public void ZoomIn(double X, double Y)
        {
            try
            {
                if (m_ImageRow0 == null)
                {
                    HTuple hv_HeightWin = null, hv_WidthWin = null;
                    HOperatorSet.GetImageSize(mImage, out hv_WidthWin, out hv_HeightWin);
                    m_ImageRow0 = 0;
                    m_ImageCol0 = 0;
                    m_ImageRow1 = hv_HeightWin;
                    m_ImageCol1 = hv_WidthWin;
                }
                HTuple Row0_1, Row1_1, Col0_1, Col1_1;
                Row0_1 = m_ImageRow0 - (Y - mWindowHandle.ImagePart.Y) * 0.05;
                Row1_1 = m_ImageRow1 + (mWindowHandle.ImagePart.Height - Y) * 0.05;
                Col0_1 = m_ImageCol0 - (X - mWindowHandle.ImagePart.X) * 0.05;
                Col1_1 = m_ImageCol1 + (mWindowHandle.ImagePart.Width - X) * 0.05;
                mWindowHandle.HalconWindow.ClearWindow();
                HOperatorSet.SetPart(mWindowHandle.HalconWindow, Row0_1, Col0_1, Row1_1, Col1_1);
                HOperatorSet.DispObj(mImage, mWindowHandle.HalconWindow);
                m_ImageRow0 = Row0_1;
                m_ImageCol0 = Col0_1;
                m_ImageRow1 = Row1_1;
                m_ImageCol1 = Col1_1;
            }
            catch
            {

            }
        }
        /// <summary>
        /// 适合图像
        /// </summary>
        public void ZoomFit()
        {
            try
            {
                HTuple hv_HeightWin = null, hv_WidthWin = null;
                HOperatorSet.GetImageSize(mImage, out hv_WidthWin, out hv_HeightWin);
                m_ImageRow0 = 0;
                m_ImageCol0 = 0;
                m_ImageRow1 = hv_HeightWin;
                m_ImageCol1 = hv_WidthWin;
                mWindowHandle.HalconWindow.ClearWindow();
                HOperatorSet.SetPart(mWindowHandle.HalconWindow, m_ImageRow0, m_ImageCol0, m_ImageRow1, m_ImageCol1);
                HOperatorSet.DispObj(mImage, mWindowHandle.HalconWindow);
            }
            catch
            {

            }
        }
        /// <summary>
        ///释放
        /// </summary>
        public void Dispose()
        {
            try
            {
                HOperatorSet.GenEmptyObj(out mImage);
                mImage.Dispose();
                GC.Collect();
            }
            catch
            {
                GC.Collect();
            }
        }
    }


    public class Circle
    {
        public double hv_Row1 = 100;
        public double hv_Column1 = 100;
        public double hv_radis = 5;
    }

    public class Rect
    {
        public double hv_Row1 = 100;
        public double hv_Column1 = 100;
        public double hv_Row2 = 300;
        public double hv_Column2 = 300;
    }

    public class RectAffine
    {
        public double hv_Row1 = 100;
        public double hv_Column1 = 100;
        public double hv_Row2 = 300;
        public double hv_Column2 = 300;
        public double hv_phi = 0;
    }
}
