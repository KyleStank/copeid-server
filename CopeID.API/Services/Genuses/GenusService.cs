﻿using CopeID.API.QueryModels.Genuses;
using CopeID.Context;
using CopeID.Models.Genuses;

namespace CopeID.API.Services.Genuses
{
    public interface IGenusService : IBaseEntityService<Genus, GenusQueryModel> { }

    public class GenusService : BaseEntityService<Genus, GenusQueryModel>, IGenusService
    {
        public GenusService(CopeIdDbContext context) : base(context) { }
    }
}