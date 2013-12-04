using SJSUParking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SJSUParking.Controllers.DataAccess
{
    public class DAL
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnStr"].ToString());

        public static LoginModel UserIsValid(LoginModel loginModel)
        {
            //bool authenticated = false;
            string query = string.Format("Select * FROM Users Where SJSUId = '{0}' AND Password = '{1}' ", loginModel.SJSUId, loginModel.Password);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                loginModel.authenticated = sdr.HasRows;// if the table has rows with the required data then the login is authenticated\
                sdr.Read();
                loginModel.Type = sdr.GetString(7);
            }
            conn.Close();
            return (loginModel);
        }

        public static UserModel UserProfile(string username)
        {
            string query = string.Format("Select * FROM Users Where SJSUId = '{0}' ", username);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            UserModel userInfo = new UserModel();
            sdr.Read();
            userInfo.SJSUId = sdr.GetString(0);
            userInfo.Email = sdr.GetString(2);
            userInfo.FirstName = sdr.GetString(3);
            userInfo.LastName = sdr.GetString(4);
            userInfo.Phone = sdr.GetString(5);
            userInfo.DrivingLicNo = sdr.GetString(6);
            conn.Close();
            return (userInfo);
        }

        public static void CreateNewUser(UserModel usermodel)
        {
            string query = string.Format("Insert into Users (SJSUId, Password, Email, FirstName, LastName, Phone, DrivingLicNo,Type) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}')",
            usermodel.SJSUId, usermodel.Password, usermodel.Email, usermodel.FirstName, usermodel.LastName, usermodel.Phone, usermodel.DrivingLicNo,"Student");
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            conn.Close();
        }

        public static void InsertUserParkingReservation(ReservedParkingModel reservedParkingModel)
        {
            string query = string.Format("Insert into Reservation (garage_name, slot_id , start_datetime, end_datetime,SJSUId) values ('{0}', '{1}', '{2}', '{3}','{4}')"
              , reservedParkingModel.GarageName, reservedParkingModel.SelectedParkingSlotId, reservedParkingModel.StartDateTime, reservedParkingModel.EndDateTime,reservedParkingModel.SJSUId);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            conn.Close();
        }

        public static List<ParkingSlotModel> GetAvailableSlots(ReservedParkingModel reservedParkingModel)
        {
            string query = string.Format("SELECT * FROM ParkingSlot Where garage_name = '" + reservedParkingModel.GarageName + "' and type ='" + reservedParkingModel.type+ "' and  slot_id Not in (Select slot_id FROM Reservation Where ('" + reservedParkingModel.StartDateTime.Replace("/", "") + "' between start_datetime and end_datetime " +
              "or '"+reservedParkingModel.EndDateTime.Replace("/","")+"' between start_datetime and end_datetime " +
              "or start_datetime between '" + reservedParkingModel.StartDateTime.Replace("/", "") + "' and '" + reservedParkingModel.EndDateTime.Replace("/", "") + "'" +
              "or end_datetime between '" + reservedParkingModel.StartDateTime.Replace("/", "") + "' and '" + reservedParkingModel.EndDateTime.Replace("/", "") + "' ));");

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            var result = new List<ParkingSlotModel>();
            while (reader.Read())
            {
                var availableSlot = new ParkingSlotModel(); 
                availableSlot.GarageName = reader.GetString(0);
                availableSlot.SlotId = reader.GetString(1);
                availableSlot.Floor = Int32.Parse((string)reader.GetSqlString(2));
                availableSlot.Type = reader.GetString(3);
                result.Add(availableSlot);
            }
            conn.Close();

            return result;
        }
    }
}