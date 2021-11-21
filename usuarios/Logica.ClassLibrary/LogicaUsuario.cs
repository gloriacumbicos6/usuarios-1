﻿using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaUsuario
    {

        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();
        
        public static List<Usuario> getAllaUsers()
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A');
                
                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener usuario" + ex.Message);
            }
        }

        public static Usuario getUserXId(int idUsuario)
        {
            try
            {
                var Usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                                              && data.usu_id.Equals(idUsuario)).FirstOrDefault();

                return Usuario;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario" + ex.Message);
            }
        }
        public static Usuario getUserXLogin(string email, string clave)
        {
            try
            {
                var Usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                                              && data.usu_correo.Equals(email)
                                              && data.usu_password.Equals(clave)
               ).FirstOrDefault();

                return Usuario;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario" + ex.Message);
            }
        }
        public static bool saveUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                dataUsuario.usu_add = DateTime.Now;
                dataUsuario.usu_status = 'A';

                dc.Usuario.InsertOnSubmit(dataUsuario);
                // Commit a la clave
                //Commit=
                dc.SubmitChanges();

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar usuario" + ex.Message);
            }
        }
        public static bool updateUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;

                // Commit a la clave
                //Commit=
                dc.SubmitChanges();

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al modificar usuario" + ex.Message);
            }
        }
        public static bool deleteUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;

                dataUsuario.usu_status = 'A';

                // Commit a la clave
                //Commit=
                dc.SubmitChanges();

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al eliminar usuario" + ex.Message);
            }
        }
    }
}
