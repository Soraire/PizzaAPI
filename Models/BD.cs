using System.Data.SqlClient;
using PizzaAPI.API.Controllers;
using System;
using Dapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace PizzaAPI.API.Models
{
    public static class BD
    {
        private static string _connectionString =  @"Server=A-PHZ2-AMI-011;DataBase=DAI-Pizzas;Trusted_Connection=True";
        public static List<Pizza> ObtenerPizza()
        {
            List<Pizza> lista = new List<Pizza>();
            string sql = "SELECT * FROM Pizzas";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                lista = db.Query<Pizza>(sql).AsList();
            }
            return lista;
        }

        public static Pizza ObtenerPizzaPorID(int id)
        {
            Pizza NuevaPizza = null;
            string sql = "SELECT * FROM Pizzas WHERE Id = @pid";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                NuevaPizza = db.QueryFirstOrDefault<Pizza>(sql, new {pId = id});
            }
            return NuevaPizza;
        }

        public static void AgregarPizza(Pizza newPiz){
        string sql = "INSERT INTO Pizzas VALUES (@pId, @pNombre, @pGluten, @pImporte, @pDescripcion)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new { pId=newPiz.Id, pNombre = newPiz.Nombre, pGluten = newPiz.LibreGluten, pImporte = newPiz.Importe, pDescripcion=newPiz.Descripcion});
        }
        }

        public static void EliminarPizza(int IdPizza){
            string sql = "DELETE FROM Pizzas WHERE Id = @pId";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                db.Execute(sql, new { pId = IdPizza });
            }
        }

        public static void ActualizarPizza(int id, Pizza pizza){
        string sql = "UPDATE Pizzas VALUES (@pId, @pNombre, @pGluten, @pImporte, @pDescripcion)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new { pId=newPiz.Id, pNombre = newPiz.Nombre, pGluten = newPiz.LibreGluten, pImporte = newPiz.Importe, pDescripcion=newPiz.Descripcion});
        }
        }
    }
}


