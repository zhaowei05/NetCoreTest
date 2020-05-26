using DAL;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class RedisBll
    {
        public static RedisClient redis { get { return new RedisDal().redis; } }
    }
}
