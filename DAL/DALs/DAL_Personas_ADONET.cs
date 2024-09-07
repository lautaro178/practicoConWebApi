﻿using DAL.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DAL.DALs
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {
        private string connectionString = "Server=DESKTOP-9MUIN73\\SQLEXPRESS;Database=Practico1;User Id=sa;Password=231002lib;";

        public void AddPersona(Persona persona)
        {
            //agregra una nueva persona a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Personas (Nombre, Apellido, Cedula, Edad) VALUES ('{persona.Nombre}', '{persona.Apellido}', '{persona.Documento}', '{persona.Edad}')";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeletePersona(string id)
        {
            //elimina una persona de la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Personas WHERE Cedula = '{id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Persona GetPersona(string id)
        {
            //obtiene una persona de la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Personas WHERE Cedula = '{id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Persona persona = new Persona();
                    //persona.Id = reader.GetInt64(0);
                    persona.Nombre = reader.GetString(1);
                    persona.Apellido = reader.GetString(2);
                    persona.Documento = reader.GetString(3);
                    persona.Edad = reader.GetInt32(4);
                    return persona;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Persona> GetPersonas()
        {
            //obtiene todas las personas de la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Personas";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Persona> personas = new List<Persona>();
                while (reader.Read())
                {
                    Persona persona = new Persona();
                    //persona.Id = reader.GetInt64(0);
                    persona.Nombre = reader.GetString(3);
                    persona.Apellido = reader.GetString(2);
                    persona.Documento = reader.GetString(1);
                    persona.Edad = reader.GetInt32(4);
                    personas.Add(persona);
                }
                return personas;
            }
        }

        public void UpdatePersona(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
