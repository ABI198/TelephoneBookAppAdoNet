using ABISoft.TelephoneBookAppAdoNet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABISoft.TelephoneBookAppAdoNet.DataAccess
{
    public class DataLogicLayer
    {
        SqlConnection connection;
        SqlCommand command;
        int returningValuesCount;
        public DataLogicLayer()
        {
            connection = new SqlConnection("Data Source=DESKTOP-473BNVL; Initial Catalog=TelephoneBookDb; User id=sa; Password=mssql1234;");
        }
        
        public void SetConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            else
                connection.Close();
        }

        public int AddTelephoneBookUser(TelephoneBookUser telephoneBookUser)
        {
            try
            {
                command = new SqlCommand("INSERT INTO TelephoneBookUsers (Id, Firstname, Lastname, PhoneNumber1, PhoneNumber2, PhoneNumber3, Email, WebSiteUrl, Address, Description )" +
                                         "VALUES (@Id, @Firstname, @Lastname, @PhoneNumber1, @PhoneNumber2, @PhoneNumber3, @Email, @WebSiteUrl, @Address, @Description )", connection);
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = telephoneBookUser.Id;
                command.Parameters.Add("@Firstname", SqlDbType.NVarChar).Value = telephoneBookUser.Firstname;
                command.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = telephoneBookUser.Lastname;
                command.Parameters.Add("@PhoneNumber1", SqlDbType.NVarChar).Value = telephoneBookUser.PhoneNumber1;
                command.Parameters.Add("@PhoneNumber2", SqlDbType.NVarChar).Value = telephoneBookUser.PhoneNumber2;
                command.Parameters.Add("@PhoneNumber3", SqlDbType.NVarChar).Value = telephoneBookUser.PhoneNumber3;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = telephoneBookUser.Email;
                command.Parameters.Add("@WebSiteUrl", SqlDbType.NVarChar).Value = telephoneBookUser.WebSiteUrl;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = telephoneBookUser.Address;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = telephoneBookUser.Description;
                SetConnection();
                returningValuesCount = command.ExecuteNonQuery(); 
            }
            catch (Exception)
            {
                
            }
            finally
            {
                SetConnection();
            }
            return returningValuesCount;
        }

        public int UpdateTelephoneBookUser(TelephoneBookUser telephoneBookUser)
        {
            try
            {
                command = new SqlCommand("UPDATE TelephoneBookUsers SET FirstName = @Firstname, LastName = @Lastname, PhoneNumber1 = @PhoneNumber1, PhoneNumber2 = @PhoneNumber2, PhoneNumber3 = @PhoneNumber3, Email = @Email, WebSiteUrl = @WebSiteUrl, Address = @Address, Description = @Description WHERE Id = @Id", connection);
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = telephoneBookUser.Id;
                command.Parameters.Add("@Firstname", SqlDbType.NVarChar).Value = telephoneBookUser.Firstname;
                command.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = telephoneBookUser.Lastname;
                command.Parameters.Add("@PhoneNumber1", SqlDbType.NVarChar).Value = telephoneBookUser.PhoneNumber1;
                command.Parameters.Add("@PhoneNumber2", SqlDbType.NVarChar).Value = telephoneBookUser.PhoneNumber2;
                command.Parameters.Add("@PhoneNumber3", SqlDbType.NVarChar).Value = telephoneBookUser.PhoneNumber3;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = telephoneBookUser.Email;
                command.Parameters.Add("@WebSiteUrl", SqlDbType.NVarChar).Value = telephoneBookUser.WebSiteUrl;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = telephoneBookUser.Address;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = telephoneBookUser.Description;
                SetConnection();
                returningValuesCount = command.ExecuteNonQuery(); 
            }
            catch (Exception)
            {

            }
            finally
            {
                SetConnection();
            }
            return returningValuesCount;
        }

        public int DeleteTelephoneBookUser(Guid id)
        {
            try
            {
                command = new SqlCommand("DELETE TelephoneBookUsers WHERE Id = @Id", connection);
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
                SetConnection();
                returningValuesCount = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                SetConnection();
            }
            return returningValuesCount;
        }

        public SqlDataReader GetTelephoneBookUsers()
        {
            command = new SqlCommand("SELECT * FROM TelephoneBookUsers", connection);
            SetConnection();
            return command.ExecuteReader();
        }

        public SqlDataReader GetTelephoneBookUserById(Guid id)
        {
            command = new SqlCommand("SELECT * FROM TelephoneBookUsers Where Id = @id", connection);
            command.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            SetConnection();
            return command.ExecuteReader();
        }

        public int UserControl(User user)
        {
            try
            {
                command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password", connection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
                SetConnection();
                returningValuesCount = (int)(command.ExecuteScalar()); 
            }
            catch (Exception)
            {

            }
            finally
            {
                SetConnection();
            }
            return returningValuesCount;
        }
    }
}
