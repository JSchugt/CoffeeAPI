using CoffeeShop.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Repositories
{
    public class CoffeeRepository
    {

        private readonly string _connectionString;
        public CoffeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }
        public List<Coffee> GetAll()
        {


            using (SqlConnection conn = Connection)
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"SELECT c.ID = cid, c.BeanVarietyId = cvid, c.Title, b.Name, b.Region, b.Notes, b.ID
                                        FROM Coffee as c;";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BeanVariety bean = new BeanVariety()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ID")),

                        };

                    }
                }

            }
        }

        public void Add(Coffee coffee) { }

        public Coffee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Coffee coffee) { }

        public void Delete(int id) { }
    }
}
