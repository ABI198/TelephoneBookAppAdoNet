using ABISoft.TelephoneBookAppAdoNet.DataAccess;
using ABISoft.TelephoneBookAppAdoNet.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABISoft.TelephoneBookAppAdoNet.Business
{
    public class BusinessLogicLayer
    {
        DataLogicLayer dal;
        public BusinessLogicLayer()
        {
            dal = new DataLogicLayer();
        }

        public int AddTelephoneBookUser(Guid id, string firstName, string lastName, string phoneNumber1, string phoneNumber2, string phoneNumber3,
            string address, string email, string websiteUrl, string description)
        {
            int result;
            if (id != Guid.Empty && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(phoneNumber1))
            {
                TelephoneBookUser telephoneBookUser = new TelephoneBookUser();
                telephoneBookUser.Id = id;
                telephoneBookUser.Firstname = firstName;
                telephoneBookUser.Lastname = lastName;
                telephoneBookUser.PhoneNumber1 = phoneNumber1;
                telephoneBookUser.PhoneNumber2 = phoneNumber2;
                telephoneBookUser.PhoneNumber3 = phoneNumber3;
                telephoneBookUser.Email = email;
                telephoneBookUser.Address = address;
                telephoneBookUser.WebSiteUrl = websiteUrl;
                telephoneBookUser.Description = description;
                result = dal.AddTelephoneBookUser(telephoneBookUser);
            }
            else
            {
                result = -100; //Missing Parameter Error Code
            }
            return result;
        }

        public int UpdateTelephoneBookUser(Guid id, string firstName, string lastName, string phoneNumber1, string phoneNumber2, string phoneNumber3,
            string address, string email, string websiteUrl, string description)
        {
            int result = 0;
            if (id != Guid.Empty && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(phoneNumber1))
            {
                TelephoneBookUser telephoneBookUser = new TelephoneBookUser();
                telephoneBookUser.Id = id;
                telephoneBookUser.Firstname = firstName;
                telephoneBookUser.Lastname = lastName;
                telephoneBookUser.PhoneNumber1 = phoneNumber1;
                telephoneBookUser.PhoneNumber2 = phoneNumber2;
                telephoneBookUser.PhoneNumber3 = phoneNumber3;
                telephoneBookUser.Email = email;
                telephoneBookUser.Address = address;
                telephoneBookUser.WebSiteUrl = websiteUrl;
                telephoneBookUser.Description = description;
                result = dal.UpdateTelephoneBookUser(telephoneBookUser);
            }
            else
            {
                result = -100; //Missing Parameter Error Code
            }
            return result;
        }

        public int DeleteTelephoneBookUser(Guid id)
        {
            int result = 0;
            if(id != Guid.Empty)
            {
                result = dal.DeleteTelephoneBookUser(id);
            }
            else
            {
                result = 101; //Missing Id Error
            }
            return result;
        }

        public List<TelephoneBookUser> GetTelephoneBookUsers()
        {
            List<TelephoneBookUser> telephoneBookUsers = new List<TelephoneBookUser>();
            try
            {
                SqlDataReader reader = dal.GetTelephoneBookUsers();
                while (reader.Read())
                {
                    telephoneBookUsers.Add(new TelephoneBookUser()
                    {
                        Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        Firstname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Lastname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PhoneNumber1 = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        PhoneNumber2 = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        PhoneNumber3 = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        WebSiteUrl = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Address = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Description = reader.IsDBNull(9) ? string.Empty : reader.GetString(9)
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                dal.SetConnection();
            }
            return telephoneBookUsers;
        }

        public TelephoneBookUser GetTelephoneBookUserById(Guid id)
        {
            TelephoneBookUser telephoneBookUser = new TelephoneBookUser();
            try
            {
                SqlDataReader reader = dal.GetTelephoneBookUserById(id);
                while (reader.Read())
                {
                    telephoneBookUser.Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0);
                    telephoneBookUser.Firstname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    telephoneBookUser.Lastname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    telephoneBookUser.PhoneNumber1 = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    telephoneBookUser.PhoneNumber2 = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    telephoneBookUser.PhoneNumber3 = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                    telephoneBookUser.Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    telephoneBookUser.WebSiteUrl = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    telephoneBookUser.Address = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                    telephoneBookUser.Description = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                }
                reader.Close();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                dal.SetConnection();
            }
            return telephoneBookUser;
        }

        public int UserControl(string username, string password)
        {
            int result = 0;
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                User user = new User()
                {
                    Username = username,
                    Password = password
                };
                result = dal.UserControl(user); //result => 1 -> user was found  , result = 0 -> user was not found
            }
            else
            {
                result = -100; //Missing Parameter Error Code
            }
            return result;
        }
    }
}
