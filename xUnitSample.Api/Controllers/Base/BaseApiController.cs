using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using xUnitSample.Core.Service.Abstract;
using xUnitSample.Model.Abstract;

namespace xUnitSample.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseApiController<TModel> : ControllerBase
        where TModel : class, IBaseModel, new()
    {
        private readonly IService<TModel, Guid> service;

        public BaseApiController(IService<TModel, Guid> service)
        {
            this.service = service;
        }

        //GET api/{controller}/{id}
        public virtual TModel GetById(Guid id)
        {
            var model = service.GetById(id);
            if(model is null)
            {
                throw new NullReferenceException();
            }
            return model;
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return service.GetAll();
        }

        //POST api/{controller}/
        [HttpPost]
        public virtual IActionResult Post([FromBody] TModel model)
        {
            service.Insert(model);
            return Ok(model.Id);
        }


        //PUT api/{controller}/
        [HttpPut]
        public virtual IActionResult Put([FromBody] TModel model)
        {
            var isModelExist = GetById(model.Id);
            if(isModelExist is null)
            {
                throw new NullReferenceException("Model not found!");
            }

            service.Update(model);
            return Ok(model);
        }

        //DELETE api/{controller}/{id}
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            service.Delete(id);
            return Ok(id);
        }
    }
}
