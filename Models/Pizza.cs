using Microsoft.AspNetCore.Mvc;
namespace PizzaAPI.API.Models
{
    public class Pizza
    {
        private int _id;
        private string _nombre;
        private bool _libreGluten;
        private int _importe;
        private string _descripcion;
        
        public int Id
        {
            get
            {
                return _id;
            }
            set{
                _id = value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set{
                _nombre = value;
            }
        }

          public bool LibreGluten
        {
            get
            {
                return _libreGluten;
            }
            set{
                _libreGluten = value;
            }
        }
        public int Importe
        {
            get
            {
                return _importe;
            }
            set{
                _importe = value;
            }
        }
         public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set{
                _descripcion = value;
            }
        }
    } 
}