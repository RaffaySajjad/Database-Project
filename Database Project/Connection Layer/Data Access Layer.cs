using System;
using System.Data;
using System.Data.SqlClient;

namespace Database_Project.Connection_Layer
{
    public class Data_Access_Layer
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
        public int registerAccount(string cnic, string email, string password, string fName, string lName)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("registerAccount", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@fName", SqlDbType.VarChar).Value = fName;
                cmd.Parameters.Add("@lName", SqlDbType.VarChar).Value = lName;
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int registerAsCustomer(string cnic, string pAddress)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("registerCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@pAddress", SqlDbType.VarChar).Value = pAddress;
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int registerAsPharmacy(string cnic, string taxNo, string pName, string pAddress)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("registerPharmacy", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@taxNo", SqlDbType.VarChar).Value = taxNo;
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = pName;
                cmd.Parameters.Add("@pAddress", SqlDbType.VarChar).Value = pAddress;
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int registerAsDoctor(string cnic, int experience, string regNo, string specialization, float charges)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("registerDoctor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@experience", SqlDbType.Int).Value = experience;
                cmd.Parameters.Add("@regNo", SqlDbType.VarChar).Value = regNo;
                cmd.Parameters.Add("@specialization", SqlDbType.VarChar).Value = specialization;
                cmd.Parameters.Add("@charges", SqlDbType.Float).Value = charges;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public int authenticateUser(string email, string password)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = -1;
            try
            {
                cmd = new SqlCommand("authenticateUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@Exists", SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                result = (int)cmd.Parameters["@Exists"].Value;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }


        public String getAccountType(String email)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            string accountType = "";
            try
            {
                cmd = new SqlCommand("getAccountType", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;


                cmd.Parameters.Add("@accountType", SqlDbType.VarChar, 10);
                cmd.Parameters["@accountType"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                accountType = cmd.Parameters["@accountType"].Value.ToString();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return accountType;
        }

        public float getCartTotal(String cnic)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            float totalPrice = 0;
            try
            {
                cmd = new SqlCommand("getCartTotal", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;


                cmd.Parameters.Add("@total", SqlDbType.Float);
                cmd.Parameters["@total"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                try
                {
                    totalPrice = float.Parse(cmd.Parameters["@total"].Value.ToString());
                }
                catch
                {
                    totalPrice = 0;
                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return totalPrice;
        }

        public String getPharmacyName(String email)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            string pharmacyName = "";
            try
            {
                cmd = new SqlCommand("getPharmacyName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;


                cmd.Parameters.Add("@pharmacyName", SqlDbType.VarChar, 10);
                cmd.Parameters["@pharmacyName"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                pharmacyName = cmd.Parameters["@pharmacyName"].Value.ToString();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return pharmacyName;
        }

        public String getDoctorName(String email)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            string doctorName = "";
            try
            {
                cmd = new SqlCommand("getDoctorName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;


                cmd.Parameters.Add("@doctorName", SqlDbType.VarChar, 10);
                cmd.Parameters["@doctorName"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                doctorName = cmd.Parameters["@doctorName"].Value.ToString();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return doctorName;
        }

        public string getCNIC(string email)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            string cnic = "";
            try
            {
                cmd = new SqlCommand("getCNIC", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;


                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15);
                cmd.Parameters["@cnic"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                cnic = cmd.Parameters["@cnic"].Value.ToString();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return cnic;
        }

        public string getFirstName(string cnic)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            string fName = "";
            try
            {
                cmd = new SqlCommand("getFirstName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;


                cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 10);
                cmd.Parameters["@firstName"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                fName = cmd.Parameters["@firstName"].Value.ToString();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return fName;
        }

        public string getLastName(string cnic)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            string lName = "";
            try
            {
                cmd = new SqlCommand("getLastName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;


                cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 10);
                cmd.Parameters["@lastName"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                lName = cmd.Parameters["@lastName"].Value.ToString();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return lName;
        }

        public int fetchStock(string cnic, ref DataTable dataTable)
        {
            int Found = 0;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("fetchPharmacyStock", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cnic"].Value = cnic;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value);
                if (Found == 1)
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))

                    {
                        dataAdapter.Fill(dataSet);

                    }

                    dataTable = dataSet.Tables[0];

                }
                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return Found;

        }

        public float isCouponValid(String couponCode)
        {
            float Found = 0;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("isCouponValid", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@couponCode", SqlDbType.VarChar);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@couponCode"].Value = couponCode;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value);
                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return Found;

        }

        public void updateCouponStatus(String couponCode, string userEmail)
        {
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("updateCouponStatus", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@couponCode", SqlDbType.VarChar);
                cmd.Parameters.Add("@user", SqlDbType.VarChar);

                // set parameter values
                cmd.Parameters["@couponCode"].Value = couponCode;
                cmd.Parameters["@user"].Value = userEmail;


                cmd.ExecuteNonQuery();

                // read output value 
                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }
        }

        public void deliverCartItems(string cnic)
        {
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("deliverCartItems", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar);
                
                // set parameter values
                cmd.Parameters["@cnic"].Value = cnic;
                

                cmd.ExecuteNonQuery();

                // read output value 
                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

        }

        public int getCart(string cnic, ref DataTable dataTable)
        {
            int Found = 0;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("fetchMyCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cnic"].Value = cnic;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value);
                if (Found == 1)
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))

                    {
                        dataAdapter.Fill(dataSet);

                    }

                    dataTable = dataSet.Tables[0];

                }
                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return Found;

        }


        public int fetchDoctorServices(string cnic, ref DataTable dataTable)
        {
            int Found = 0;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("fetchDoctorServices", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cnic"].Value = cnic;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value);
                if (Found == 1)
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))

                    {
                        dataAdapter.Fill(dataSet);

                    }

                    dataTable = dataSet.Tables[0];

                }
                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return Found;

        }

        public void insertToStock(string CNIC, string medicine, int qty, float price)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addToStock", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idNum", SqlDbType.VarChar).Value = CNIC;
                cmd.Parameters.Add("@medicine", SqlDbType.VarChar).Value = medicine;
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty;
                cmd.Parameters.Add("@price", SqlDbType.Float).Value = price;


                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteFromStock(string cnic, string medicine)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;

            int result = 0;
            try
            {
                cmd = new SqlCommand("deleteFromStock", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idNum", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@medicine", SqlDbType.VarChar).Value = medicine;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int deleteFromCart(string cnic, string serviceName, String fullfilledBy)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;

            int result = 0;
            try
            {
                cmd = new SqlCommand("deleteFromMyCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@serviceName", SqlDbType.VarChar).Value = serviceName;
                cmd.Parameters.Add("@fullfilledBy", SqlDbType.VarChar).Value = fullfilledBy;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int deleteFromDoctorService(string cnic, string specialization)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;

            int result = 0;
            try
            {
                cmd = new SqlCommand("deleteFromDoctorService", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@specialization", SqlDbType.VarChar).Value = specialization;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int updateStockTable(string id, string medicine, int qty, float price)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("updateStockTable", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idNum", SqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@medicine", SqlDbType.VarChar).Value = medicine;
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty;
                cmd.Parameters.Add("@price", SqlDbType.Float).Value = price;
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int updateMyCart(string cnic, string serviceName, string fullfilledBy, float cost, int qty)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("updateMyCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@serviceName", SqlDbType.VarChar).Value = serviceName;
                cmd.Parameters.Add("@fullfilledBy", SqlDbType.VarChar).Value = fullfilledBy;
                cmd.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }


        public int updateDoctorTable(string cnic, string specialization, int experience, string regNo, float charges)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("updateDoctorTable", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@specialization", SqlDbType.VarChar).Value = specialization;
                cmd.Parameters.Add("@experience", SqlDbType.Int).Value = experience;
                cmd.Parameters.Add("@regNo", SqlDbType.VarChar).Value = regNo;
                cmd.Parameters.Add("@charges", SqlDbType.Float).Value = charges;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public void addToSubscribersList(string email)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addToSubscribe", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;                
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        public void addMedicineOrderItem(string cnic, float cost, string medicineName, string fullfilledBy)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addMedicineOrderItem", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                cmd.Parameters.Add("@medicine", SqlDbType.VarChar).Value = medicineName;
                cmd.Parameters.Add("@fullfilledBy", SqlDbType.VarChar).Value = fullfilledBy;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void deductFromStock(string medicineName, string fullfilledBy)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("deductFromStock", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@medicine", SqlDbType.VarChar).Value = medicineName;
                cmd.Parameters.Add("@fullfilledBy", SqlDbType.VarChar).Value = fullfilledBy;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void reclaimStock(string medicineName, string fullfilledBy, int qty)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("reclaimStock", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@medicine", SqlDbType.VarChar).Value = medicineName;
                cmd.Parameters.Add("@fullfilledBy", SqlDbType.VarChar).Value = fullfilledBy;
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void addServiceOrderItem(string cnic, float cost, string serviceName, string fullfilledBy)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addServiceOrderItem", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar).Value = cnic;
                cmd.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                cmd.Parameters.Add("@specialization", SqlDbType.VarChar).Value = serviceName;
                cmd.Parameters.Add("@fullfilledBy", SqlDbType.VarChar).Value = fullfilledBy;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void registerInquiry(String name, String email, String number, String message)
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("registerInquiry", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@number", SqlDbType.VarChar).Value = number;
                cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = message;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public int getMedicineStock(ref DataTable dataTable)
        {
            int Found = 0;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("getMedicineStock", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value);
                if (Found == 1)
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))

                    {
                        dataAdapter.Fill(dataSet);

                    }

                    dataTable = dataSet.Tables[0];

                }
                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return Found;

        }

        public int SearchMedicineStock(String Name, ref DataTable DT)
        {
            int Found = 0;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("searchMedicineStock ", connection); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@medicine", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@medicine"].Value = Name;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(dataSet);

                    }

                    DT = dataSet.Tables[0];

                }


                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public int SearchDoctorServices(String Specialization, ref DataTable DT)
        {
            int Found = 0;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("searchSpecializationServices", connection); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@specialization", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@specialization"].Value = Specialization;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(dataSet);

                    }

                    DT = dataSet.Tables[0];

                }


                connection.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return Found;

        }


    }
}
