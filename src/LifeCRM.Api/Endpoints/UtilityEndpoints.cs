using LifeCRM.Api.Data;
using LifeCRM.Api.Entities;
using LifeCRM.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LifeCRM.Api.Endpoints
{
    public static class UtilityEndpoints
    {
        public static RouteGroupBuilder MapUtilityEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/utilities").WithTags("Utilities");

            group.MapGet("/", async (LifeCrmDbContext db) =>
            {
                var entities = await db.UtilityContracts.ToListAsync();
                var dtos = entities.Select(e => new UtilityContractDto
                {
                    Id = e.Id,
                    Category = e.Category,
                    Alias = e.Alias,
                    ProviderName = e.ProviderName,
                    PlanName = e.PlanName,
                    CommitmentEndDate = e.CommitmentEndDate,
                    IsActive = e.IsActive
                });

                return Results.Ok(dtos);
            });

            // GET: Read contract by ID
            group.MapGet("/{id:guid}", async (Guid id, LifeCrmDbContext db) =>
            {
                var entity = await db.UtilityContracts.FindAsync(id);
                if (entity is null) return Results.NotFound();

                var dto = new UtilityContractDto
                {
                    Id = entity.Id,
                    Category = entity.Category,
                    Alias = entity.Alias,
                    ProviderName = entity.ProviderName,
                    PlanName = entity.PlanName,
                    CommitmentEndDate = entity.CommitmentEndDate,
                    IsActive = entity.IsActive
                };

                return Results.Ok(dto);
            });

            // POST: Create a new contract
            group.MapPost("/", async (UtilityContractDto dto, LifeCrmDbContext db) =>
            {
                var entity = new UtilityContractEntity
                {
                    Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
                    Category = dto.Category,
                    Alias = dto.Alias,
                    ProviderName = dto.ProviderName,
                    PlanName = dto.PlanName,
                    CommitmentEndDate = dto.CommitmentEndDate,
                    IsActive = dto.IsActive
                };

                db.UtilityContracts.Add(entity);
                await db.SaveChangesAsync();

                dto.Id = entity.Id;
                return Results.Created($"/api/utilities/{entity.Id}", dto);
            });

            // PUT: Update an existing contract
            group.MapPut("/{id:guid}", async (Guid id, UtilityContractDto dto, LifeCrmDbContext db) =>
            {
                var entity = await db.UtilityContracts.FindAsync(id);
                if (entity is null) return Results.NotFound();

                entity.Category = dto.Category;
                entity.Alias = dto.Alias;
                entity.ProviderName = dto.ProviderName;
                entity.PlanName = dto.PlanName;
                entity.CommitmentEndDate = dto.CommitmentEndDate;
                entity.IsActive = dto.IsActive;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            // DELETE: Remove a contract
            group.MapDelete("/{id:guid}", async (Guid id, LifeCrmDbContext db) =>
            {
                var entity = await db.UtilityContracts.FindAsync(id);
                if (entity is null) return Results.NotFound();

                db.UtilityContracts.Remove(entity);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
