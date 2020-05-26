using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RedisDal
    {
        private string host { get { return "localhost:6379"; } }
        public RedisClient redis { get { return new RedisClient(host); }}
    }
}
