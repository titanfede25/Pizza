using System.Data.SqlClient;
using System;
using Dapper;
using System.Collections.Generic;

namespace Nueva_carpeta.Models
{
    public static class BD
    {
        private static string _connectionString =  @"Server=A-PHZ2-AMI-012;DataBase=DAI-Pizzas;Trusted_Connection=True";
        public static List<Pizza> GetAll()
        {
            List<Pizza> lista = new List<Pizza>();
            string sql = "SELECT * FROM Pizzas";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                lista = db.Query<Pizza>(sql).AsList();
            }
            return lista;
        }
        public static Pizza GetById(int Id)
        {
            Pizza ObjetoPizza = null;
            string sql = "SELECT * FROM Pizzas WHERE Id =@pid";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                ObjetoPizza = db.QueryFirstOrDefault<Pizza>(sql, new {pid = Id});
            }
            return ObjetoPizza;
        }
        public static void Create(Pizza pizza)
        {
            string sql = "INSERT INTO Pizzas VALUES (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new {pNombre=pizza.Nombre, pLibreGluten=pizza.LibreGluten, pImporte=pizza.Importe, pDescripcion=pizza.Descripcion});
            }   
        }
        public static void Update(Pizza pizza, int Id)
        {
            string sql = "update Pizzas set Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripcion = @pDescripcion WHERE Id = @pId";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pId = pizza.Id, pNombre = pizza.Nombre, pLibreGluten = pizza.LibreGluten, pImporte = pizza.Importe, pDescripcion = pizza.Descripcion});
            }
        }   
        public static void DeleteById(int Id)
        {
            string sql = "DELETE FROM Pizzas WHERE Id = @pId";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pId = Id });
            }
        }
    }
}