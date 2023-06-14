using SW.Domain.CustomExceptions;
using SW.Domain.DTOs;
using SW.Domain.ServicesImplementations;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SW.DistributedSystems.Controllers
{
    public class RebelsController : ApiController
    {
        private readonly IServicesRebels _servicesRebels;

        public RebelsController(IServicesRebels services)
        {
            _servicesRebels = services;
        }

        // POST: api/Rebels
        /// <summary>
        /// Register a new rebel in the register
        /// </summary>
        /// <param name="payload">JSON array containing the name of the Rebel and the planet they were spotted on</param>
        /// <response code="200">OK. Returns true</response>
        /// <response code="400">BadRequest. Returns a message with the encountered error</response>
        public IHttpActionResult Post([FromBody] List<string> payload)
        {
            try
            {
                RebelDTO rebelDTO = new RebelDTO().MappingPayloadToDTO(payload);
                _servicesRebels.AddRebel(rebelDTO);

                return Ok(true);
            }
            catch (ParsingReqPayloadException ex)
            {
                return BadRequest($"Error trying to read the information: {ex.Message}");
            }
            catch (SavingToFileException ex)
            {
                return BadRequest($"Error trying to save the information: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error trying to process your request: {ex.Message}");
            }
        }

    }

}
