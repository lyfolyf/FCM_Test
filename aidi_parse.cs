using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//json解析需要的库
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//需要用到opencv解析
using OpenCvSharp;

namespace aqrose.aidi_vision_client
{
    //aidi2.1返回的json解析用的类
    public class ContoursPoint
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class ImageSize
    {
        public float width { get; set; }
        public float height { get; set; }
    }

    public class Outer
    {
        public List<ContoursPoint> points { get; set; }
    }

    public class inners
    {
        public List<List<ContoursPoint>> points { get; set; }
    }

    public class Polygon
    {
        public Outer outer { get; set; }
        public List<ContoursPoint> inners { get; set; }
    }

    public class Region
    {
        public Polygon polygon { get; set; }
        public string name { get; set; }
        public float score { get; set; }
        public List<ContoursPoint> key_points { get; set; }
        public Dictionary<string, string> ext_info { get; set; }
    }

    public class AIDIResult
    {
        public string dataset_type { get; set; }
        public ImageSize img_size { get; set; }
        public string name { get; set; }
        public float score { get; set; }
        public List<Region> regions { get; set; }
        public List<Region> masks { get; set; }
        public List<Region> hardcases { get; set; }
        public Dictionary<string, string> origin_result { get; set; }
        public Dictionary<string, string> ext_info { get; set; }
    }

    public class RegionInfo
    {
        public float area { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public float centerX { get; set; }
        public float centerY { get; set; }
        public float score { get; set; }
        public string label { get; set; }
        public List<ContoursPoint> contour { get; set; }
    }

    //AidiParse类，里面包含一些解析会用到的方法
    public class ResultParser
    {

        //将模型输出的json字符串直接解析成AidiResult类型
        static public AIDIResult Parse(string result_string)
        {

            //使用Newtonsoft直接解析
            var parse_result = Newtonsoft.Json.Linq.JObject.Parse(result_string);

            //格式转换
            AIDIResult aidi_result = parse_result.ToObject<AIDIResult>();

            //返回
            return aidi_result;

        }

        //从AIDIResult中计算出各轮廓的面积，长宽等的内容，一张图片对应一个AIDIResult，对应一个List<RegionInfo>
        public static List<RegionInfo> AbstractRegionInfo(AIDIResult aidiresult)
        {

            //初始化最后要反回的List<region_info>
            List<RegionInfo> region_info_list = new List<RegionInfo>();

            //先取出所有region
            List<Region> regions = aidiresult.regions;

            //遍历region
            for (int i = 0; i < regions.Count; i++)
            {

                //新建region_info
                RegionInfo region_info = new RegionInfo();

                //取出对应region
                Region region = regions[i];

                //将轮廓点转换成opencv格式
                List<OpenCvSharp.Point> points = new List<OpenCvSharp.Point>();
                Outer outer = region.polygon.outer;
                for (int j = 0; j < outer.points.Count; j++)
                {
                    points.Add(new OpenCvSharp.Point(outer.points[j].x, outer.points[j].y));
                }

                //用opencv计算
                double area = Cv2.ContourArea(points);
                RotatedRect r_rect = Cv2.MinAreaRect(points);// 斜
                Rect bounding_rect = r_rect.BoundingRect();//正

                //配置region_info
                region_info.area = (float)area;
                region_info.centerX = r_rect.Center.X;
                region_info.centerY = r_rect.Center.Y;
                region_info.contour = region.polygon.outer.points;
                region_info.height = r_rect.Size.Height;
                region_info.width = r_rect.Size.Width;
                //region_info.centerX = ((bounding_rect.TopLeft + bounding_rect.BottomRight) / 2).X;
                //region_info.centerY = ((bounding_rect.TopLeft + bounding_rect.BottomRight) / 2).Y;
                //region_info.contour = region.polygon.outer.points;
                //region_info.height = bounding_rect.Size.Height;
                //region_info.width = bounding_rect.Size.Width;


                region_info.label = region.name;
                region_info.score = region.score;

                //将region_info加入结果
                region_info_list.Add(region_info);

            }

            //返回结果
            return region_info_list;

        }

        //字符串gb2312编码转utf-8编码
        public static string gb2312_to_utf8(string text)
        {
            //声明转换器
            System.Text.Encoding utf8, gb2312;
            //utf8   
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            //gb2312   
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            //用gb2312读出byte[]
            byte[] byte_gb2312 = gb2312.GetBytes(text);
            //将读出的byte[]由gb2312转换成utf8格式
            byte[] byte_utf8 = System.Text.Encoding.Convert(gb2312, utf8, byte_gb2312);
            //用utf8格式读上边的结果
            string utf_string = utf8.GetString(byte_utf8);
            //返回
            return utf_string;
        }

        //字符串utf-8编码转gb2312编码
        public static string utf8_to_gb2312(string text)
        {
            //声明转换器
            System.Text.Encoding utf8, gb2312;
            //utf8   
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            //gb2312   
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            //用utf-8读出byte[]
            byte[] byte_utf8 = utf8.GetBytes(text);
            //将读出的byte[]由utf8转换成gb2312格式
            byte[] byte_gb2312 = System.Text.Encoding.Convert(utf8, gb2312, byte_utf8);
            //用utf8格式读上边的结果
            string right_string = gb2312.GetString(byte_gb2312);
            //返回
            return right_string;
        }
    }
}
