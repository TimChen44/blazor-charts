﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
public     class ElementSeries<T>:Element
    {
        public ElementSeries(SeriesType type)
        {
            SeriesType = type;
        }

        public Func<T, string> ArgumentField { get; set; }

        public Func<T, double> ValueField { get; set; }

        public SeriesType SeriesType { get; set; }
    }

    public enum SeriesType
    {
        Bar,
    }
}