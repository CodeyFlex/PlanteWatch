using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi
{
    public class Token
    {
        private string token = "Your Token";

        public string TokenValueApi
        {
            get => token;
            set => token = value;
        }
    }
}
