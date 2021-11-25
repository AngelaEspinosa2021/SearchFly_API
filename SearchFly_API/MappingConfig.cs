﻿using AutoMapper;
using SearchFly_API.Models;
using SearchFly_API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FlightDto, Flight>();
                config.CreateMap<Flight, FlightDto>();
            });

            return mappingConfig;
        }

    }
}
