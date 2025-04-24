using System.ComponentModel;

namespace Stoqa.ProductCatalog.Domain.Enums;

public enum EMessage : byte
{
    [Description("O campo {0} é obrigatório.")]
    Required,

    [Description("{0} com valor lógico inválido.")]
    InvalidValue,

    [Description("Item não foi encontrado")]
    ItemNotFound,

    [Description("Item já foi lido em outra ordem de venda")]
    ItemFoundOrder,

    [Description("Item já está reservado para outra operação")]
    ItemInvalidStatus
}