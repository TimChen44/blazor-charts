using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public class RemoteDataSource<TData> : DataSourceBase<TData>
    {
        public RemoteDataSource()
        {

        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Timer.Interval = 10000;
                Timer.Enabled = false;
                Timer.Elapsed += Timer_Elapsed;
                await LoadData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task LoadData()
        {
            if (IsRunning == true) return;
            IsRunning = true;

            if (LoadDataFunc == null) return;
            var data = await LoadDataFunc();
            Chart.DataChange(data);

            IsRunning = false;
        }


        [Display(Name = "数据载入", Description = "自定义数据载入方法，返回图表所需数据")]
        [Parameter] public Func<Task<IEnumerable<TData>>> LoadDataFunc { get; set; }


        /// <summary>
        /// 定时器
        /// </summary>
        System.Timers.Timer Timer = new System.Timers.Timer();

        [Display(Name = "刷新间隔（毫秒）", Description = "自动请求数据的时间间隔")]
        [Parameter]
        public double Interval
        {
            get => Timer.Interval;
            set => Timer.Interval = value;
        }

        [Display(Name = "启动自动刷新", Description = "每隔Interval的时间刷新数据")]
        [Parameter]
        public bool AutoRefresh
        {
            get => Timer.Enabled;
            set => Timer.Enabled = value;
        }


        bool IsRunning = false;

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await InvokeAsync(LoadData);
        }
    }
}
