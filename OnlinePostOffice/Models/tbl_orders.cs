//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlinePostOffice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_orders
    {
        public int id { get; set; }
        public string title { get; set; }
        public string tracking_number { get; set; }
        public string sender_name { get; set; }
        public string sender_phone { get; set; }
        public string sender_location { get; set; }
        public Nullable<int> service_id { get; set; }
        public string reciver_name { get; set; }
        public string reciver_phone { get; set; }
        public string reciver_location { get; set; }
        public string date_sender { get; set; }
        public string date_reciver { get; set; }
        public Nullable<int> user_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Nullable<int> cost { get; set; }
        public Nullable<int> weights { get; set; }
        public string status { get; set; }
    }
}
