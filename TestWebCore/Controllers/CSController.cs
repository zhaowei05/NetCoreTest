using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestWebCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CSController : ControllerBase
    {
        private BLL.IBaseBll<Model.CS> bll = new BLL.CSBll(x => x.GetMySql());
        [HttpPost]
        public IActionResult GetPage(int index, int page)
        {
            IList<Model.CS> list = bll.GetPageList(index,page,x=>true,out int count);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Get(string ID)
        {
            Model.CS cs = bll.Get(ID);
            return Ok(cs);
        }

        [HttpDelete]
        public IActionResult Delete(string ID)
        {
            ID = "";
            var msg= bll.Dels(new dynamic[]{ID});
            return Ok(msg);
        }

        [HttpPut]
        public IActionResult Update(Model.CS  cS)
        {
            var msg = bll.Update(cS);
            return Ok(msg);
        }

        [HttpPut]
        public IActionResult Add(Model.CS cS)
        {
            var msg = bll.Add(cS);
            return Ok(msg);
        }
    }
}