﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BtcTurkApi.Client.Models
{
    public class OrderInput
    {
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal StopPrice { get; set; }
        public string NewOrderClientId { get; set; }
        public OrderMethod OrderMethod { get; set; }
        public OrderType OrderType { get; set; }
        public string PairSymbol { get; set; }
    }

    public enum OrderType
    {
        Buy,
        Sell
    }

    public enum OrderMethod
    {
        Limit,
        Market,
        StopLimit,
        StopMarket
    }
}