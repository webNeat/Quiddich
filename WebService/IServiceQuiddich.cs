using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceQuiddich" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceQuiddich
    {
        [OperationContract]
        IList<CoupeWS> GetAllCoupes();
    }
}
