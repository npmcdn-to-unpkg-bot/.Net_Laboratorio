using DALayer.Api;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Scheduler
{
    public class DestacamentoUpload : IJob
    {
        private DALayer.Interfaces.IApi api;
        private string tenantId;

        private void init(string _tenantId)
        {
            api = new EFApi();
            tenantId = _tenantId;
            api.setTenant(tenantId);
        }

        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string tenantId = dataMap.GetString("tenantId");
            int relJugDestId = System.Int32.Parse(dataMap.GetString("relJugId"));
            int cantidad = System.Int32.Parse(dataMap.GetString("cantidad"));
            init(tenantId);

            var rel = api.getRelJugadorDestacamentoHandler().getRelJugadorDestacamento(relJugDestId);
            rel.cantidad += cantidad;
            api.getRelJugadorDestacamentoHandler().executeUpdate(rel);
        }
    }
}
