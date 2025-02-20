using System;
using System.Collections.Generic;

namespace JFESM.Web.Validators
{
    public class ValidationResult
    {
        private readonly Dictionary<Type, object> dataMap = new Dictionary<Type, object>();

        public bool HasError
        {
            get
            {
                if(string.IsNullOrWhiteSpace(ErrorMessage)){
                    return false;
                }

                return true;
            }
        }
        public string ErrorMessage { get; set; }

        public void AddResult(object data)
        {
            dataMap.Add(data.GetType(), data);
        }

        public R GetResult<R>() where R : class
        {
            object data;
            dataMap.TryGetValue(typeof(R), out data);
            return (R)data;
        }
    }
}