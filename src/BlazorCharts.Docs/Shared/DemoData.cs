using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts.Docs.Shared
{
    /// <summary>
    /// 示例数据
    /// </summary>
    static class DemoData
    {
        public static List<Github> Githubs = new List<Github>()
        {
            new Github(){Year=2017,View =2500,Start=800,Fork=400},
            new Github(){Year=2018,View =2200,Start=900,Fork=800},
            new Github(){Year=2019,View =2800,Start=1100,Fork=700},
            new Github(){Year=2020,View =2600,Start=1400,Fork=900},
        };

        public static List<CityValue> CityValues = new List<CityValue>()
        {
            new CityValue(){Year=2020,City ="上海",Value=26},
            new CityValue(){Year=2020,City ="北京",Value=23},
            new CityValue(){Year=2021,City ="上海",Value=32},
            new CityValue(){Year=2021,City ="北京",Value=35},
            new CityValue(){Year=2022,City ="上海",Value=29},
            new CityValue(){Year=2022,City ="北京",Value=34},
        };
    }
    public class Github
    {
        public int Year { get; set; }
        public int View { get; set; }
        public int Start { get; set; }
        public int Fork { get; set; }
    }



    public class CityValue
    {
        public int Year { get; set; }
        public string City { get; set; }
        public int Value { get; set; }
    }

}
