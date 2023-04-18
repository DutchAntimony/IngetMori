using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.FamilieRoot.TelefoonNummers;

public record struct TelefoonNummerId(Guid Value) : IEntityKey;
