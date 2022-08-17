using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Infrastructure.RuntimeExecution
{
    public class SharedTestExecution<TIn, TOut>
    {

        //public abstract TOut Run(SourceCodeItem<TIn, TOut> item);


        public virtual Func<TIn, TOut> FuncToTest { get; set; }

        public TOut RunTest(TIn parameter)
        {
            if (FuncToTest is null)
                return default;

            TOut RetVal = FuncToTest.Invoke(parameter);

            return RetVal;
        }
    }
}
