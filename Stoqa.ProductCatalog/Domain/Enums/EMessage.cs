using System.ComponentModel;

namespace Stoqa.ProductCatalog.Domain.Enums;

public enum EMessage : byte
{
    [Description("O campo {0} é obrigatório.")]
    Required,

    [Description("{0} com valor lógico inválido.")]
    InvalidValue,

    [Description("Item já foi lido")] ItemFound,

    [Description("Item já foi lido em outra ordem de venda")]
    ItemFoundOrder
}