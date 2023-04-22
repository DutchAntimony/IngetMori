using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.Core.Errors;
public static partial class DomainErrors<TEntity>
    where TEntity : IEntity
{ 
        public static Error NotFound => 
            new($"{nameof(TEntity)}.{nameof(NotFound)}",
                $"{nameof(TEntity)} met het opgegeven Id niet gevonden");

        public static Error NonFound => 
            new($"{nameof(TEntity)}.{nameof(NonFound)}",
                $"Geen {nameof(TEntity)} gevonden die aan het opgegeven filter voldoen");

        public static Error NoIdProvided => 
            new($"{nameof(TEntity)}.{nameof(NoIdProvided)}",
                $"Geen Id meegegeven voor opzoeken of updaten van {nameof(TEntity)}");
}
