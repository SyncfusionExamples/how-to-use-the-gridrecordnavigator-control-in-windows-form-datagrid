﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_WF
{
    public class OrderInfo
    {
        Double? orderID;
        string customerId;
        string country;
        string customerName;
        string shippingCity;
        DateTime? date;
       
        public Double? OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        public string CustomerID
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string ShipCity
        {
            get { return shippingCity; }
            set { shippingCity = value; }
        }

        public DateTime? DateTime
        {
            get { return date; }
            set { date = value; }
        }
        public OrderInfo()
        {

        }

        public OrderInfo(Double? orderId, string customerName, string country, string customerId, string shipCity,DateTime? date)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
            this.DateTime = date;
        }
    }
}
