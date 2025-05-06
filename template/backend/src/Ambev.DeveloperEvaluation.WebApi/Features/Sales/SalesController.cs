using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using Ambev.DeveloperEvaluation.Application.Sales.Queries;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<SaleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSalesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SaleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetSaleQuery { Id = id };
            var result = await _mediator.Send(query);
            
            if (result == null)
                return NotFound(new { message = $"Venda {id} não encontrada" });

            return Ok(result);
        }

        /// <summary>
        /// Cria uma nova venda
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(CreateSaleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateSaleCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/sales/{result.Id}", result);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var command = new CancelSaleCommand { Id = id };
            var result = await _mediator.Send(command);
            
            if (result)
                return Ok(new { message = $"Venda {id} cancelada com sucesso" });
            
            return NotFound(new { message = $"Venda {id} não encontrada" });
        }
    }
}
