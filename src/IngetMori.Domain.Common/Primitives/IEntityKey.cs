namespace IngetMori.Domain.Common.Primitives;

public interface IEntityKey
{
    Guid Value { get; set; }
}