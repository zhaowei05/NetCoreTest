using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace TestWebCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CSController : ControllerBase
    {
        private readonly IBaseBll<CS> bll = new CSBll(x => x.GetMySql());

        [HttpPost]
        public IActionResult GetPage(int index, int page)
        {
            var list = bll.GetPageList(index, page, x => true, out var count);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Get(string ID)
        {
            var cs = bll.Get(ID);
            return Ok(cs);
        }

        [HttpDelete]
        public IActionResult Delete(string ID)
        {
            ID = "";
            var msg = bll.Dels(new dynamic[] {ID});
            return Ok(msg);
        }

        [HttpPut]
        public IActionResult Update(CS cS)
        {
            var msg = bll.Update(cS);
            return Ok(msg);
        }

        [HttpPut]
        public IActionResult Add(CS cS)
        {
            var msg = bll.Add(cS);
            return Ok(msg);
        }
    }
}