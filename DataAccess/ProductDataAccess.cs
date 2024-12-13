using System.Data;
using CMSMVCApp.Models;
using MySql.Data.MySqlClient;

namespace CMSMVCApp.DataAccess;

public class ProductDataAccess
{
    string ConnString = "Server=localhost;port=3306;database=cms;user=root;password=Lavssubbu123@";

    public IEnumerable<Product> DisplayAll()
    {
        List<Product> lstproducts = new List<Product>();
        using (MySqlConnection conn = new MySqlConnection(ConnString))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("GetProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Execute the query
            MySqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Product pro = new Product
                {
                    ProdId = Convert.ToInt32(sdr["ProdId"]),
                    ProName = sdr["ProName"].ToString(),
                    Price = Convert.ToDecimal(sdr["Price"])
                };
                lstproducts.Add(pro);
            }
        }
        return lstproducts;
    }
    public Product GetById(int id)
    {
        Product prod = null;
        using (MySqlConnection conn = new MySqlConnection(ConnString))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("GetProductbyId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);//mapping db procedure parameter with method parameter

            //Execute the query
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                prod = new Product
                {
                    ProdId = sdr.GetInt32("ProdId"),
                    ProName = sdr.GetString("ProName"),
                    Price = sdr.GetDecimal("Price")
                };

            }
        }
        return prod;
    }
    public void AddProd(Product prod)
    {

        using (MySqlConnection conn = new MySqlConnection(ConnString))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("AddProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Pname", prod.ProName);
            cmd.Parameters.AddWithValue("@price", prod.Price);

            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateProd(Product prod)
    {
        using (MySqlConnection conn = new MySqlConnection(ConnString))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UpdateProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Proid", prod.ProdId);
            cmd.Parameters.AddWithValue("@proname", prod.ProName);
            cmd.Parameters.AddWithValue("@price", prod.Price);

            cmd.ExecuteNonQuery();
        }
    }
}
