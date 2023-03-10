using System.Data.SqlClient;
using PizzaAPI.API.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace PizzaAPI.API.Models
{
    public static class BD
    {
        private static string _connectionString =  @"Server=A-PHZ2-CIDI-010;DataBase=DAI-Pizzas;Trusted_Connection=True";
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

        public static void AgregarAutos(Pizza newPizza){
        string sql = "INSERT INTO Autos VALUES (@pIdAuto, @pIdMarca, @pMarca, @pModelo, @pPrecio, @pFechaCreacion, @pFoto1, @pFoto2, @pFoto3)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new { pIdAuto=Aut.IdAuto, pIdMarca = Aut.IdMarca, pMarca = Aut.Marca, pModelo = Aut.Modelo, pPrecio = Aut.Precio, pFechaCreacion=Aut.FechaCreacion, pFoto1=Aut.Foto1, pFoto2=Aut.Foto2, pFoto3=Aut.Foto3 });
        }
        }

        public static void EliminarAuto(int IdAuto){
            string sql = "DELETE FROM Autos WHERE IdAuto = @pIdAuto";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                db.Execute(sql, new { pIdAuto = IdAuto });
            }
        }
    }
}


