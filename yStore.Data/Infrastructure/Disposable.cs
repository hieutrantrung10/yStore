using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yStore.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDispose;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if(!isDispose && disposing)
            {
                DisposeCore();
            }
            isDispose = true;
        }

        protected virtual void DisposeCore()
        {

        }
    }
}
