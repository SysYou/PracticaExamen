using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DAL
{
    public class Mantenimiento : IMantenimiento
    {
        private static Mantenimiento instancia;

        public static Mantenimiento Instancia
        {
            get
            {
                if (instancia == null)
                {
                    return new Mantenimiento();
                }
                return instancia;

            }
            set
            {
                if (instancia == null)
                {
                    instancia = value;
                }
            }
        }

        public void Insertar(DO.Persona persona)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            DbConnection conn = null;

            DbCommand comm = null;



            try
            {

                conn = factory.CreateConnection();

                conn.ConnectionString = Settings.Default.connection;

                comm = factory.CreateCommand();



                DbParameter param1 = factory.CreateParameter();

                DbParameter param2 = factory.CreateParameter();

                DbParameter param3 = factory.CreateParameter();

                DbParameter param4 = factory.CreateParameter();

                DbParameter param5 = factory.CreateParameter();
                DbParameter param6 = factory.CreateParameter();


            


               


                param1.ParameterName = "@vNombre";

                param1.DbType = System.Data.DbType.String;
                

                param1.Value = persona.VNombre;



                param2.ParameterName = "@iGenero";

                
                param2.DbType = System.Data.DbType.Int32;

                param2.Value = persona.IGenero;



                param3.ParameterName = "@vCategoria";

                param3.DbType = System.Data.DbType.String;

                param3.Value = persona.VCategoria;



                param4.ParameterName = "@iValor";
            
                param4.DbType = System.Data.DbType.Decimal;

                param4.Value = persona.IValor;



                param5.ParameterName = "@bDisponible";

                param5.DbType = System.Data.DbType.Boolean;

                param5.Value = persona.BDisponible;



                //Abrir Coneccion 

                comm.Connection = conn;

                conn.Open();



                //Ejecutar Store Procedure

                comm.CommandType = System.Data.CommandType.StoredProcedure;

                comm.CommandText = "sp_Insertar";

                comm.Parameters.Add(param1);

                comm.Parameters.Add(param2);

                comm.Parameters.Add(param3);

                comm.Parameters.Add(param4);

                comm.Parameters.Add(param5);

               

                comm.ExecuteNonQuery();

            }

            catch (Exception ee)
            {

                throw;

            }

            finally
            {

                comm.Dispose();

                conn.Dispose();

            }
        }

        public List<DO.Persona> Mostrar()
        {
            //Inicializamos
            List<Persona> lista = new List<Persona>();

            //Conex
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();
                //Abrir connection 
                comm.Connection = conn;
                conn.Open();

                //Ejecuta SP
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "sp_Mostrar";

                using (IDataReader dataReader = comm.ExecuteReader())
                {
                    Persona persona;
                    while (dataReader.Read())
                    {
                        persona = new Persona();

                        persona.IId = Convert.ToInt32(dataReader["iId"].ToString());
                        persona.VNombre = dataReader["vNombre"].ToString();
                        persona.IGenero = dataReader["vGenero"].ToString();
                        persona.VCategoria = dataReader["vCategoria"].ToString();
                        persona.IValor = Convert.ToInt32(dataReader["iValor"].ToString());
                        persona.BDisponible = Convert.ToBoolean(dataReader["bDisponible"].ToString());


                        //Convert.ToBoolean(dataReader["bMuerto"].ToString());

                        lista.Add(persona);
                    }
                }
                return lista;
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void Actualizar(DO.Persona persona)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                DbParameter param1 = factory.CreateParameter();
                DbParameter param2 = factory.CreateParameter();
                DbParameter param3 = factory.CreateParameter();
                DbParameter param4 = factory.CreateParameter();
                DbParameter param5 = factory.CreateParameter();
                DbParameter param6 = factory.CreateParameter();

                //Carga de Parametros
                param1.ParameterName = "@iId";
                param1.DbType = System.Data.DbType.Int32;
                param1.Value = persona.IId;

                param2.ParameterName = "@vNombre";
                param2.DbType = System.Data.DbType.String;
                param2.Value = persona.VNombre;

                param3.ParameterName = "@iGenero";
                //param3.DbType = System.Data.DbType.Boolean;
                param3.DbType = System.Data.DbType.Int32;
                param3.Value = persona.IGenero;

                param4.ParameterName = "@vCategoria";
                param4.DbType = System.Data.DbType.String;  
                param4.Value = persona.VCategoria;

                param5.ParameterName = "@iValor";
                param5.DbType = System.Data.DbType.Int32;
                param5.Value = persona.IValor;

                param6.ParameterName = "@bDisponible";
                param6.DbType = System.Data.DbType.Boolean;
                param6.Value = persona.BDisponible;

                //Abrir Coneccion 
                comm.Connection = conn;
                conn.Open();

                //Ejecutar Store Procedure
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "sp_Actualizar";
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
                comm.Parameters.Add(param4);
                comm.Parameters.Add(param5);
                comm.Parameters.Add(param6);
                comm.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                comm.Dispose();
                conn.Dispose();
            }
        }

        public void Borrar(DO.Persona persona)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

            DbConnection conn = null;

            DbCommand comm = null;



            try
            {

                conn = factory.CreateConnection();

                conn.ConnectionString = Settings.Default.connection;

                comm = factory.CreateCommand();



                DbParameter param1 = factory.CreateParameter();





                //Carga de Parametros

                param1.ParameterName = "@iId";

                param1.DbType = System.Data.DbType.Int32;

                param1.Value = persona.IId;


                //Abrir Coneccion 

                comm.Connection = conn;

                conn.Open();



                //Ejecutar Store Procedure

                comm.CommandType = System.Data.CommandType.StoredProcedure;

                comm.CommandText = "sp_Eliminar";

                comm.Parameters.Add(param1);

                comm.ExecuteNonQuery();

            }

            catch (Exception ee)
            {

                throw;

            }

            finally
            {

                comm.Dispose();

                conn.Dispose();

            }
        }
    }
}
