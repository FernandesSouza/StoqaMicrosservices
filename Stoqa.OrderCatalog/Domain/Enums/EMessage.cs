using System.ComponentModel;

namespace Stoqa.OrderCatalog.Domain.Enums;

public enum EMessage : byte
{
    [Description("O campo {0} é obrigatório.")]
    Required,

    [Description("{0} com valor lógico inválido.")]
    InvalidValue,
    
    [Description("{0} não permitido ou erro no servidor")]
    ErrorConferenceUpdate,
    
   
}