using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using CourseWork.Helpers.Constants;


namespace CourseWork.DAL.CRM
{
    public class CRMContext: IDisposable
    {
        CrmServiceClient service;
        public CrmServiceClient Service { get { return service; } }

        private bool disposed = false;

        public CRMContext(string connectionString)
        {
            service = new CrmServiceClient(connectionString);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Service.Dispose();
                }
                this.disposed = true;

            }
        }
    }
}
