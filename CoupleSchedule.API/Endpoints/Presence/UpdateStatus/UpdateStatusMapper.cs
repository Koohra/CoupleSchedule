using CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.UpdateStatus;

public sealed class UpdateStatusMapper : Mapper<UpdateStatusRequest, UpdateStatusResponse, UpdateStatusCommand>
{
    public override UpdateStatusCommand ToEntity(UpdateStatusRequest r) => new(
        PartnerId: Guid.Empty,
        Activity: r.Activity,
        Focus: r.FocusId
    );
    
    public UpdateStatusResponse ToResponse(bool success) => new(
        Success: success,
        Message: success ? "Status atualizado com sucesso!" : "Falha ao atualizar status."
    );
}