using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace train
{
    class DBConnector
    {

        SqlConnection con = null;

        public SqlConnection getConnection()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Train"].ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: DBConnector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;





        }



    }
}
