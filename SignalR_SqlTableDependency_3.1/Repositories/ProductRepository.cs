﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SignalR_SqlTableDependency_3._1.Models;

namespace SignalR_SqlTableDependency_3._1.Repositories
{
    public class ProductRepository
    {
        readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            Product product;

            var data = GetProductDetailsFromDb();

            foreach (DataRow row in data.Rows)
            {
                product = new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Category = row["Category"].ToString(),
                    Price = Convert.ToDecimal(row["Price"])
                };
                products.Add(product);
            }

            return products;
        }

        public DataTable GetProductDetailsFromDb()
        {
            var query = "SELECT Id, Name, Category, Price FROM Product";
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    return dataTable;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
