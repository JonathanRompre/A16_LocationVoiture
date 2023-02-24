using A16_TP_1142718_JRompre.Models;
using Microsoft.Data.SqlClient;

namespace A16_TP_1142718_JRompre.DAO
{
    public class SystemDao
    {
        ConnectionManager connectionManager;
        SqlConnection conn;

        public SystemDao(IConfiguration _cfg)
        {
            connectionManager = ConnectionManager.getInstance(_cfg);
        }

        public List<Automobile> GetAutoLouees()
        {
            try
            {
                SqlCommand cmd;
                SqlDataReader reader;
                List<Automobile> listAutomobiles;

                conn = connectionManager.getNewConnection();
                cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "getAutoLouees";
                cmd.Connection = conn;

                conn.Open();
                reader = cmd.ExecuteReader();
                listAutomobiles = new List<Automobile>();
                while (reader.Read())
                {
                    Automobile automobile = new Automobile();
                    automobile.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    automobile.Annee = reader.GetInt32(reader.GetOrdinal("Annee"));
                    automobile.Marque = reader.GetString(reader.GetOrdinal("Marque"));
                    automobile.Model = reader.GetString(reader.GetOrdinal("Model"));
                    automobile.Motopropulsion = reader.GetString(reader.GetOrdinal("Motopropulsion"));
                    automobile.Transmission = reader.GetString(reader.GetOrdinal("Transmission"));
                    automobile.Licence = reader.GetString(reader.GetOrdinal("Licence"));
                    automobile.Prix = reader.GetDouble(reader.GetOrdinal("Prix"));
                    listAutomobiles.Add(automobile);
                }
                return listAutomobiles;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Automobile>();
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<Automobile> GetAutoDispo()
        {
            try
            {
                SqlCommand cmd;
                SqlDataReader reader;
                List<Automobile> listAutomobiles;

                conn = connectionManager.getNewConnection();
                cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "getAutoDispo";
                cmd.Connection = conn;

                conn.Open();
                reader = cmd.ExecuteReader();
                listAutomobiles = new List<Automobile>();
                while (reader.Read())
                {
                    Automobile automobile = new Automobile();
                    automobile.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    automobile.Annee = reader.GetInt32(reader.GetOrdinal("Annee"));
                    automobile.Marque = reader.GetString(reader.GetOrdinal("Marque"));
                    automobile.Model = reader.GetString(reader.GetOrdinal("Model"));
                    automobile.Motopropulsion = reader.GetString(reader.GetOrdinal("Motopropulsion"));
                    automobile.Transmission = reader.GetString(reader.GetOrdinal("Transmission"));
                    automobile.Licence = reader.GetString(reader.GetOrdinal("Licence"));
                    automobile.Prix = reader.GetDouble(reader.GetOrdinal("Prix"));
                    listAutomobiles.Add(automobile);
                }
                return listAutomobiles;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Automobile>();
            }
            finally
            {
                conn.Close();
            }
        }

        public int GetReservationPourAutoId(int autoId)
        {
            try
            {
                SqlCommand cmd;
                SqlDataReader reader;

                conn = connectionManager.getNewConnection();
                cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "trouverReservationIdPourAutoId";
                cmd.Parameters.Add(new SqlParameter("@autoId", autoId));
                cmd.Connection = conn;

                conn.Open();
                reader = cmd.ExecuteReader();
                int resId = -1;
                while (reader.Read())
                {
                    resId = reader.GetInt32(reader.GetOrdinal("Id"));
                }
                return resId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool deleteReservation(Reservation reservation)
        {
            try
            {
                SqlCommand cmd;

                conn = connectionManager.getNewConnection();
                cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "deleteReservation";
                cmd.Parameters.Add(new SqlParameter("@id", reservation.Id));
                cmd.Connection = conn;

                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool addHistoriqueReservation(Reservation res)
        {
            try
            {
                SqlCommand cmd;

                conn = connectionManager.getNewConnection();
                cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "addHistoriqueReservation";
                cmd.Parameters.Add(new SqlParameter("@autoId", res.AutomobileId));
                cmd.Parameters.Add(new SqlParameter("@clientId", res.Client.Id));
                cmd.Parameters.Add(new SqlParameter("@dateRes", res.DateReservation));
                cmd.Parameters.Add(new SqlParameter("@dateSor", res.DateSortie));
                cmd.Connection = conn;

                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
