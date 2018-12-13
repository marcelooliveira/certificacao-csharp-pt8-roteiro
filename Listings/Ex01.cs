using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Listings
{
    class Ex01
    {
        class Animal
        {
            public string Cor { get; set; }
            public string Nome { get; set; }
        }
        private static IEnumerable<Animal> GetAnimais(string sqlConnectionString)
        {
            var animais = new List<Animal>();
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            using (sqlConnection)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Nome, Cor FROM Animals", sqlConnection);

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {

                    {
                        var animal = new Animal();
                        animal.Nome = (string)sqlDataReader["Nome"];
                        animal.Cor = (string)sqlDataReader["Cor"];
                        animais.Add(animal);
                    }
                }
            }
            return animais;
        }
    }
}
