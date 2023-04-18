using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.FamilieRoot.EmailAdressen;

public record struct EmailAdresId(Guid Value) : IEntityKey;
