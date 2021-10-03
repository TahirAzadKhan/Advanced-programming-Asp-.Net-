using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Lab_Task___CRUD.Models.Tables;

namespace Lab_Task___CRUD.Models
{
    public class Database
    {
        public Products Products { get; set; }
       
        public Database()
        {
            string connString = @"Server=KRATOS\SQLEXPRESS;Database=Products;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Products = new Products(conn);
          
        }
    }
}