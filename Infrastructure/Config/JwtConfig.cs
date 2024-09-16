using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class JwtConfig
    {
        public int LifeTimeInMin { get; set; }
        public int ExpiredOtpInSeconds { get; set; }
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
