using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceKrispy
{
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        ValidaCupon ValidarCupon(int idCupon);
        
    }
    
    [DataContract]
    public class ValidaCupon
    {        
        [DataMember]
        public int ValidaCuponID { get; set; }
        [DataMember]
        public string MensajeValidacion { get; set; }        
    }
}
