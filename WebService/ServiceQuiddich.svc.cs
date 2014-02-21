using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceQuiddich" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceQuiddich.svc ou ServiceQuiddich.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceQuiddich : IServiceQuiddich
    {
        public void DoWork()
        {
        }
        public IList<CoupeWS> GetAllCoupes()
        {
            return null;
        }
    }
}
