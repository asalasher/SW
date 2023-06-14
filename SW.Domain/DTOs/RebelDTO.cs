using SW.Domain.CustomExceptions;
using System.Collections.Generic;

namespace SW.Domain.DTOs
{

    public class RebelDTO
    {
        public string Name { get; set; }
        public string PlanetName { get; set; }
    }

    public static class ExtensionsPixelDTO
    {
        public static Rebel MappingToDomainEntity(this RebelDTO pxDTO)
        {
            return new Rebel
            {
                Name = pxDTO.Name,
                PlanetName = pxDTO.PlanetName
            };
        }

        public static RebelDTO MappingPayloadToDTO(this RebelDTO rebelDTO, List<string> payload)
        {
            if (payload.Count != 2)
            {
                throw new ParsingReqPayloadException("The number of fields must be 2");
            }

            if (string.IsNullOrEmpty(payload[0]) || string.IsNullOrEmpty(payload[1]))
            {
                throw new ParsingReqPayloadException("The fields can not be empty");
            }
            else
            {
                rebelDTO.Name = payload[0];
                rebelDTO.PlanetName = payload[1];
            }

            return rebelDTO;
        }

    }

}
