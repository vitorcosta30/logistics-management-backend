using logistics_management_backend.DTO.Requests;
using logistics_management_backend.Services.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace logistics_management_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly IRequestService _service;

    public RequestsController( IRequestService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<ActionResult<RequestDTO>> CreateRequest(RequestItemDTO[] items )
    {  
        try
        {
            var req = await _service.addRequest(items);
            if (req == null)
            {
                return Problem("There has been an error, the request was not created!!");
            }
            return CreatedAtAction("CreateRequest", new { id = items }, req);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }

    }

    [HttpGet("getAllToBeProcessed")]
    public async Task<ActionResult<List<RequestDTO>>> GetRequestsToBeProcessed()
    {
        return await _service.getAllToBeProcessedAsync();

    }
    
    [HttpGet("getAllToBeReceived")]
    public async Task<ActionResult<List<RequestDTO>>> GetRequestsToBeReceived()
    {
        return await _service.getAllToBeReceivedAsync();

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<RequestDTO>> getRequestById(long id)
    {
        return await _service.getRequestById(id);

    }

    [HttpPatch("collectItem/{idRequest}/{idItem}")]
    public async Task<ActionResult<RequestDTO>> CollectItem(long idRequest, long idItem)
    {
        try
        {
            return await _service.collectedItem(idRequest,idItem);
        }
        catch(Exception e)
        {
            return Problem(e.Message);

        }
    }


    [HttpPatch("startProcessing/{id}")]
    public async Task<ActionResult<RequestDTO>> StartProcessing(long id)
    {
        try
        {
            return await _service.startProcessing(id);

        }
        catch(Exception e)
        {
           return Problem(e.Message);

        }
    }
    [HttpPatch("sendRequest/{id}")]
    public async Task<ActionResult<RequestDTO>> SendRequest(long id)
    {
        try
        {
            return await _service.sendRequest(id);

        }
        catch(Exception e)
        {
            return Problem(e.Message);

        }
    }
    [HttpPatch("receiveRequest/{id}")]
    public async Task<ActionResult<RequestDTO>> ReceiveRequest(long id)
    {
        try
        {
            return await _service.receiveRequest(id);

        }
        catch(Exception e)
        {
            return Problem(e.Message);

        }
    }
}