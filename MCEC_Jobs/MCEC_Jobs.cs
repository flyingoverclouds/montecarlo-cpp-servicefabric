using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace MCEC_Jobs
{
    /// <summary>
    /// Une instance de cette classe est créée pour chaque réplica de service par le runtime Service Fabric.
    /// </summary>
    internal sealed class MCEC_Jobs : StatefulService
    {
        public MCEC_Jobs(StatefulServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Substitution facultative pour créer des écouteurs (par exemple HTTP, communication à distance des services, WCF, etc.) pour ce réplica de service afin de gérer les requêtes des clients ou des utilisateurs.
        /// </summary>
        /// <remarks>
        /// Pour plus d'informations sur la communication des services, consultez https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>Collection d'écouteurs.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new ServiceReplicaListener[0];
        }

        /// <summary>
        /// Point d'entrée principal de votre réplica de service.
        /// Cette méthode s'exécute quand ce réplica de votre service devient le réplica primaire et qu'il a un statut d'écriture.
        /// </summary>
        /// <param name="cancellationToken">Annulé quand Service Fabric doit arrêter ce réplica de service.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: remplacez l'exemple de code suivant par votre propre logique 
            //       ou supprimez cette substitution de RunAsync, si elle n'est pas nécessaire dans votre service.

            var myDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, long>>("myDictionary");

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await myDictionary.TryGetValueAsync(tx, "Counter");

                    ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");

                    await myDictionary.AddOrUpdateAsync(tx, "Counter", 0, (key, value) => ++value);

                    // Si une exception est levée avant l'appel de CommitAsync, la transaction est annulée, toutes les modifications sont 
                    // ignorées, et rien n'est enregistré dans les réplicas secondaires.
                    await tx.CommitAsync();
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
