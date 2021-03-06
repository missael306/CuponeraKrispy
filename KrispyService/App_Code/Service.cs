using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{

    public ValidaCupon ValidarCupon(int idCupon)
    {
        ValidaCupon res = new ValidaCupon();
        string storeProcedure = "SpValidaCupon @CuponID";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ToString()))
        {
            SqlCommand command = new SqlCommand(storeProcedure, connection);
            command.Parameters.Add("@CuponID", SqlDbType.Int);
            command.Parameters["@CuponID"].Value = idCupon;
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            res.ValidaCuponID = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString());
            res.MensajeValidacion = DS.Tables[0].Rows[0][1].ToString();

        }
        return res;
    }

}
