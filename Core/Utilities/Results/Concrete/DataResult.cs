using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
   public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public DataResult(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, T data, string message)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }

        public DataResult(ResultStatus resultStatus, T data, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
            Exception = exception;
        }


      
    }
}
