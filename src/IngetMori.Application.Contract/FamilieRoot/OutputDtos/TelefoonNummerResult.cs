using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Application.Contract.FamilieRoot.OutputDtos;

public record TelefoonNummerResult(TelefoonNummerId Id, string Nummer, string Omschrijving);
