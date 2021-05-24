using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// 默认地址
        /// </summary>
        [Parameter] public Uri? BaseAddress { get; set; }

        private HttpClient httpClient;

        public RemoteDataSource()
        {
            httpClient = new HttpClient();

            if (BaseAddress != null)
                httpClient.BaseAddress = BaseAddress;
        }

        [Parameter] public string Url { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
            await base.OnInitializedAsync();
        }

        private async Task LoadData()
        {
            if (Uri.TryCreate(BaseAddress, Url, out Uri result) == true)
            {
                var data = await httpClient.GetFromJsonAsync<IEnumerable<TData>>(result);
                if (data != null)
                {
                    Chart.DataChange(data);
                }
            }
        }

        [Parameter] public bool AutoRefreshInterval { get; set; }

    }
}
